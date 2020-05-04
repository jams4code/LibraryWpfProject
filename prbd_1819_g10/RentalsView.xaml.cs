using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prbd_1819_g10
{
    /// <summary>
    /// Logique d'interaction pour RentalsView.xaml
    /// </summary>
    public partial class RentalsView : UserControlBase
    {
        private ObservableCollection<Rental> rentals = new ObservableCollection<Rental>() ;
        public ObservableCollection<Rental> Rentals {
            get{
                var rental = new ObservableCollection<Rental>(App.Model.Rentals.Where(l => l.RentalDate != null && l.Items.Count() > 0));
                if (App.CurrentUser.Role != Role.Admin) {
                    rental = new ObservableCollection<Rental>(App.Model.Rentals.Where(l => l.RentalDate != null && l.User.UserId == App.CurrentUser.UserId && l.Items.Count() > 0));
                }
                return rental;
            }
            set
            {
                rentals = value;
                RaisePropertyChanged(nameof(Rentals));
                if (value.Count() == 0) {
                    SelectedRental = null;
                }
                RaisePropertyChanged(nameof(SelectedRental));
                RaisePropertyChanged(nameof(RentalItems));


            }
        }
        private Rental selectedRental;
        public Rental SelectedRental {
            get => selectedRental;
            set {
                SetProperty<Rental>(ref selectedRental, value);
                RaisePropertyChanged(nameof(RentalItems));
            }
        }
        private ObservableCollection<RentalItemProxy> rentalItems = new ObservableCollection<RentalItemProxy>();
        public ObservableCollection<RentalItemProxy> RentalItems {
            get {
                rentalItems.Clear();
                if (SelectedRental != null) { 
                    foreach (RentalItem r in SelectedRental?.Items)
                    {
                        rentalItems.Add(new RentalItemProxy(r));
                    }
                }
                return rentalItems;
            }
        }
        public bool IsAdmin
        {
            get => App.CurrentUser.Role == Role.Admin;
        }
        public bool IsNotAdmin
        {
            get => App.CurrentUser.Role != Role.Admin;
        }
        
        public ICommand Return { get; set; }
        private void ReturnRental(RentalItemProxy r) {
            r.RentalItem.DoReturn();
            App.Model.SaveChanges();
            notifyAll();
            App.NotifyColleagues(AppMessage.MSG_BOOK_CHANGED, r.RentalItem.BookCopy.Book);
        }
        public ICommand Delete { get; set; }
        private void DeleteRental(RentalItemProxy r){
            Book bk = r.RentalItem.BookCopy.Book;
            App.Model.RentalItems.Remove(r.RentalItem);
            App.Model.SaveChanges();
            RentalItems.Remove(r);
            notifyAll();
            RaisePropertyChanged(nameof(SelectedRental));
            App.NotifyColleagues(AppMessage.MSG_BOOK_CHANGED, bk);
        }
        public ICommand Cancel { get; set; }
        private void CancelReturn(RentalItemProxy r)
        {
            if (!r.RentalItem.CancelReturn())
            {
                MessageBox.Show("Vous ne pouvez pas annuler le retour de ce livre, Il n'y a plus de copie disponible", "Cancel return impossible", MessageBoxButton.OK);
            }
            App.Model.SaveChanges();
            notifyAll();
            App.NotifyColleagues(AppMessage.MSG_BOOK_CHANGED, r.RentalItem.BookCopy.Book);

        }
        public RentalsView()
        {
            InitializeComponent();
            DataContext = this;
            Return = new RelayCommand<RentalItemProxy>(r => ReturnRental(r), (r) => { return App.CurrentUser.Role == Role.Admin;  });
            Cancel = new RelayCommand<RentalItemProxy>(r => CancelReturn(r), (r) => { return App.CurrentUser.Role == Role.Admin; });
            Delete = new RelayCommand<RentalItemProxy>(r => DeleteRental(r), (r) => { return App.CurrentUser.Role == Role.Admin; });
            App.Register(this,AppMessage.MSG_BASKET_UPDATED,()=> { notifyAll(); });
            App.Register<Book>(this, AppMessage.MSG_BOOK_CHANGED, (b) => { notifyAll(); });
            App.Register<Book>(this, AppMessage.MSG_BOOK_DELETED, (b) => { notifyAll(); });
        }
        public void notifyAll() {
            RaisePropertyChanged(nameof(Rentals));
            RaisePropertyChanged(nameof(RentalItems));
        }
        public bool canExec(RentalItem b) {
            return b != null && App.CurrentUser.Role != Role.Member;
        } 

    }
}

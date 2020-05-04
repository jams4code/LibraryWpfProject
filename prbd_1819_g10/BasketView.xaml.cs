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
    /// Logique d'interaction pour BasketView.xaml
    /// </summary>
    public partial class BasketView : UserControlBase
    {
        private Rental Basket { get; set; }
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get => users;
            set => SetProperty<ObservableCollection<User>>(ref users, value);
        }
        private User selectedUser;
        public User SelectedUser
        {
            get {
                if(selectedUser == null)
                    selectedUser = Users.Where(u => u.UserId == App.CurrentUser.UserId).FirstOrDefault();
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                notifyAll();
                RaisePropertyChanged(nameof(SelectedUser));
                App.NotifyColleagues(AppMessage.MSG_USER_CHANGED, selectedUser);
            }
        }
        public bool IsAdmin {
            get {
                return App.CurrentUser.Role == Role.Admin;
            }
        }
        public bool IsNotAdmin
        {
            get
            {
                return App.CurrentUser.Role != Role.Admin;
            }
        }
        private ObservableCollection<Book> books = new ObservableCollection<Book>();
        public ObservableCollection<Book> Books
        {
            get
            {
                books.Clear();
                Basket = SelectedUser?.Basket;
                if (Basket == null) return books;
                ICollection<RentalItem> ri = Basket.Items;         
                foreach (RentalItem rit in ri)
                {
                    books.Add(rit.BookCopy.Book);
                }
                return books;
            }
            set
            {
                books = value;
                notifyAll();

            }
        }
        public ICommand Confirm { get; set; }
        private void confirmBasket (){
            if (Basket != null && Books.Count()>0) {
                Basket.Confirm();
            }
            App.NotifyColleagues(AppMessage.MSG_BASKET_UPDATED);
            notifyAll();
        }
        public ICommand Clear { get; set; }
        private void clearBasket()
        {
            if (Basket != null && SelectedUser != null && Books.Count() > 0)
            {
                SelectedUser.ClearBasket();
            }
            App.NotifyColleagues(AppMessage.MSG_BASKET_UPDATED);
            notifyAll();
        }
        public ICommand DeleteRental { get; set; }
        private void deleteRental(Book b) {
            selectedUser.RemoveFromBasket(b);
            App.NotifyColleagues(AppMessage.MSG_BASKET_UPDATED);
            notifyAll();
        }
        public BasketView()
        {
            InitializeComponent();
            DataContext = this;
            Users = new ObservableCollection<User>(App.Model.Users);
            Confirm = new RelayCommand(confirmBasket);
            Clear = new RelayCommand(clearBasket);
            DeleteRental = new RelayCommand<Book>((b)=> deleteRental(b));
            App.Register(this, AppMessage.MSG_BASKET_UPDATED, () => { notifyAll(); });
        }
        public void notifyAll() {
            RaisePropertyChanged(nameof(SelectedUser));
            RaisePropertyChanged(nameof(Books));
        }
    }
}

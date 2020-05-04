using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace prbd_1819_g10
{
    public partial class BooksView : UserControlBase
    {
        //SelectedUser bind with SelectedUser from basketView
        private User selectedUser;
        public User SelectedUser
        {
            get
            {
                if(selectedUser == null)
                {
                    selectedUser = App.CurrentUser;
                }
                return selectedUser;
            }
            set { selectedUser = value; }
        }
        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books {
            get => books; 
            set=>SetProperty<ObservableCollection<Book>>(ref books,value); }
        private string filter;
        public string Filter {
            get => filter;
            set => SetProperty<string>(ref filter,value,ApplyFilterAction);
        }
        private string selectedCategory = "All";
        public string SelectedCategory
        {
            get => selectedCategory;
            set => SetProperty<string>(ref selectedCategory, value, ApplyFilterAction);
        }
        public ObservableCollection<string> Categories
        {
            get
            {
                ObservableCollection<string> s = new ObservableCollection<string>();
                s.Add("All");
                foreach (Category c in App.Model.Categories)
                {
                    s.Add(c.Name);
                };
                return s;
            }
        }
        public ICommand AddToBasket { get; set; }
        public ICommand ClearFilter { get; set; }
        public ICommand NewBook { get; set; }
        public ICommand DisplayBookDetails { get; set; }
        public ICommand SelectCat { get; set; }
        public BooksView()
        {
 
            InitializeComponent();
            DataContext = this;
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            ClearFilter = new RelayCommand(()=>{ Filter = null ; SelectedCategory = "All"; });
            Books = new ObservableCollection<Book>(App.Model.Books.OrderBy(c=>c.Title));
            //Display Book Details
            DisplayBookDetails = new RelayCommand<Book>(book=> { App.NotifyColleagues(AppMessage.MSG_DISPLAY_BOOK, book); });

            //New Book
            NewBook = new RelayCommand(() =>
            {
                App.NotifyColleagues(AppMessage.MSG_NEW_BOOK);
            },()=> { return App.CurrentUser.Role == Role.Admin; });

            AddToBasket = new RelayCommand<Book>(book => {
                SelectedUser.AddToBasket(book);
                App.NotifyColleagues(AppMessage.MSG_BASKET_UPDATED);
                ApplyFilterAction();
            }, 
            book => {
                return book == null ? false : book.NumAvailableCopies >= 1;
            });
            SelectCat = new RelayCommand<Category>((c)=> { SelectedCategory = c.Name; });


            //Rafraichir lors d'ajout new Book
            App.Register<Book>(this, AppMessage.MSG_BOOK_CHANGED, book => { ApplyFilterAction(); });
            App.Register<Book>(this, AppMessage.MSG_BOOKCOPIES_ADDED, book => { ApplyFilterAction(); });
            App.Register(this, AppMessage.MSG_CATEGORIES_UPDATED, () => { RaisePropertyChanged(nameof(Categories)); ApplyFilterAction(); });
            App.Register(this, AppMessage.MSG_BASKET_UPDATED,()=> { ApplyFilterAction(); });
            App.Register<User>(this, AppMessage.MSG_USER_CHANGED, (u) => {SelectedUser = u; });
        }
        private void ApplyFilterAction() {
            if (!string.IsNullOrEmpty(Filter) || selectedCategory != "All")
            {
                if (string.IsNullOrEmpty(Filter)) {
                    Filter = null;
                }
                List<Book> filtered = (from c in App.Model.Books
                                       where c.Title.Contains(Filter) || c.Author.Contains(Filter) || c.Categories.Any(m => m.Name == selectedCategory)
                                       select c).ToList(); ;
                if (!string.IsNullOrEmpty(Filter) && selectedCategory != "All")
                {
                    filtered = (from c in App.Model.Books
                                where (c.Title.Contains(Filter) || c.Author.Contains(Filter)) && c.Categories.Any(m => m.Name == selectedCategory)
                                select c).ToList();
                }
                Books = new ObservableCollection<Book>(filtered.OrderBy(c => c.Title));

            }
            else
            {
                Books = new ObservableCollection<Book>(App.Model.Books.OrderBy(c => c.Title));
            }
        }
    }
}

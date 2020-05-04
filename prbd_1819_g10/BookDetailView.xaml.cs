using Microsoft.Win32;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Logique d'interaction pour BookDetailView.xaml
    /// </summary>
    public partial class BookDetailView : UserControlBase
    {
        public Book Book { get; set; }
        private bool isNew;
        private ImageHelper imageHelper;
        public bool IsNew 
        {
            get { return isNew; }
            set
            {
                isNew = value;
                RaisePropertyChanged(nameof(IsNew));
                RaisePropertyChanged(nameof(IsNotNew));
            }
        }
        public bool IsNotNew
        {
            get { return !isNew; }
        }

        public String Isbn //Propriété pour le bind
        {
            get { return Book.Isbn; }
            set
            {
                Book.Isbn = value;
                RaisePropertyChanged(nameof(Isbn));
                App.NotifyColleagues(AppMessage.MSG_ISBN_CHANGED, string.IsNullOrEmpty(value) ? "<new book>" : value); //Mise a jour de l'en tête
                Validate();
            }
        }
        public String Title //Propriété pour le bind
        {
            get { return Book.Title; }
            set
            {
                Book.Title = value;
                RaisePropertyChanged(nameof(Title));
                Validate();
            }
        }
        public String Author //Propriété pour le bind
        {
            get { return Book.Author; }
            set
            {
                Book.Author = value;
                RaisePropertyChanged(nameof(Author));
                Validate();
            }
        }
        public String Editor //Propriété pour le bind
        {
            get { return Book.Editor; }
            set
            {
                Book.Editor = value;
                RaisePropertyChanged(nameof(Editor));
                Validate();
            }
        }
        public ICollection<Category> Categories //Propriété pour le bind
        {
            get { return Book.Categories; }
            set
            {
                Book.Categories = value;
                RaisePropertyChanged(nameof(Categories));
            }
        }
        public String PicturePath //Propriété pour le bind
        {
            get { return Book.AbsolutePicturePath; }
            set
            {
                Book.PicturePath = value;
                RaisePropertyChanged(nameof(PicturePath));
            }
        }
        private ObservableCollection<BookCopy> bookCopies;
        public ObservableCollection<BookCopy> BookCopies //Propriété pour le bind
        {
            
            get
            {
                bookCopies = new ObservableCollection<BookCopy>(Book.Copies);
                return bookCopies;
            }
            set
            {

                SetProperty<ObservableCollection<BookCopy>>(ref bookCopies,value);
            }
        }

        private ObservableCollection<CategoryProxy> categoriesList;
        public ObservableCollection<CategoryProxy> CategoriesList {
            get {
                categoryAdded.Clear();
                categoriesList = new ObservableCollection<CategoryProxy>();
                List<Category> allCats = App.Model.Categories.ToList();
                foreach (Category c in allCats)
                {
                    CategoryProxy prx = new CategoryProxy(c, c.HasBook(Book));
                    categoriesList.Add(prx);
                    if (c.HasBook(Book))
                    {
                        categoryAdded.Add(prx);
                    }
                }
                return categoriesList;
            }
        }
        private List<CategoryProxy> categoryAdded = new List<CategoryProxy>();
        private List<CategoryProxy> CategoryAdded
        {
            get
            {
                return categoryAdded;
            }
            set
            {
                categoryAdded = value;
            }
        }

        //DateTimePicker c
        private DateTime addCopiesDate = DateTime.Now;
        public DateTime AddCopiesDate
        {
            get { return addCopiesDate; }
            set
            {
                this.addCopiesDate = value;
                RaisePropertyChanged(nameof(addCopiesDate));
            }
        }

        //NumberOfCopies
        private int nbCopies = 1;
        public int NbCopies
        {
            get { return nbCopies; }
            set
            {
                this.nbCopies = value;
                RaisePropertyChanged(nameof(nbCopies));
            }
        }


        //Traitement de la sauvegarde du nouveau Book
        // SAVE BUTTON
        public ICommand Save { get; set; }
        
        private void SaveAction()
        {
            if (IsNew)
            {
                App.Model.Books.Add(Book);
                IsNew = false;
            }
            Book.RemoveCategories(Book.Categories.ToArray());
            Book.AddCategories((from c in categoryAdded select c.Cat).ToArray());
            App.Model.SaveChanges();
            App.NotifyColleagues(AppMessage.MSG_BOOK_CHANGED, Book);
            
            App.NotifyColleagues(AppMessage.MSG_CATEGORIES_UPDATED);
            CatChange = false;
        }
        private bool CanSaveOrCancelAction()
        {
            if (IsNew)
            {
                return !string.IsNullOrEmpty(Isbn) && !String.IsNullOrEmpty(Title) && !String.IsNullOrEmpty(Author)
                    && !String.IsNullOrEmpty(Editor) && CatChange && !HasErrors;
            }

            var change = (from c in App.Model.ChangeTracker.Entries<Book>()
                          where c.Entity == Book
                          select c).FirstOrDefault();
            return change != null && change.State != System.Data.Entity.EntityState.Unchanged || CatChange;
        }

        //Traitement du Delete BUTON
        public ICommand Delete { get; set; }
        private void DeleteAction()
        {
            var result = MessageBox.Show("Voulez vous supprimer ce livre ?", "message confirmation suppression", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) { 
                this.CancelAction();
                if (File.Exists(PicturePath))
                {
                    File.Delete(PicturePath);
                }
                Book.Delete();
                App.Model.SaveChanges();
                App.NotifyColleagues(AppMessage.MSG_BOOK_CHANGED, Book);
                App.NotifyColleagues(AppMessage.MSG_BOOK_DELETED, Book);
            }
        }

        //Traitement du Cancel BUTTON
        public ICommand Cancel { get; set; }
        private void CancelAction()
        {
            if (imageHelper.IsTransitoryState)
            {
                imageHelper.Cancel();
            }
            if (IsNew)
            {
                Isbn = null;
                Title = null;
                Author = null;
                Editor = null;
                Categories = null;
                PicturePath = imageHelper.CurrentFile;
                RaisePropertyChanged(nameof(Book));
            }
            else
            {
                var change = (from c in App.Model.ChangeTracker.Entries<Book>()
                              where c.Entity == Book
                              select c).FirstOrDefault();
                change.Reload();
                Validate();
                RaisePropertyChanged(nameof(Isbn));
                RaisePropertyChanged(nameof(Title));
                RaisePropertyChanged(nameof(Author));
                RaisePropertyChanged(nameof(Editor));
                RaisePropertyChanged(nameof(categoriesList));
                RaisePropertyChanged(nameof(PicturePath));
                RaisePropertyChanged(nameof(BookCopies));
                App.NotifyColleagues(AppMessage.MSG_ISBN_CHANGED, string.IsNullOrEmpty(Isbn) ? "<new book>" : Isbn); //Mise a jour de l'en tête
                CatChange = false;
            }
        }

        //LoadImage BUTTON
        public ICommand LoadImage { get; set; }
        private void LoadImageAction()
        {
            var fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                imageHelper.Load(fd.FileName);
                PicturePath = imageHelper.CurrentFile;
            }
        }
        //ClearImage BUTTON
        public ICommand ClearImage { get; set; }
        private void ClearImageAction()
        {
            imageHelper.Clear();
            PicturePath = imageHelper.CurrentFile;
        }
        //ADD BUTTON
        public ICommand AddCopies { get; set; }
        private void AddAction()
        {
            Book.AddCopies(NbCopies, AddCopiesDate);
            App.Model.SaveChanges();
            BookCopies = new ObservableCollection<BookCopy>(Book.Copies);
            App.NotifyColleagues(AppMessage.MSG_BOOKCOPIES_ADDED, Book);
       
        }
        public ICommand Check { get; set; }
        private void CheckCat(CategoryProxy c) {
            List<CategoryProxy> cat = new List<CategoryProxy>();
            if (!IsNew)
            {
                cat = CategoryProxy.FullCatList();
            }
            if (c.IsChecked)
            {
                categoryAdded.Add(c);
            } 
            else if (!c.IsChecked && categoryAdded.Contains(c))
            {
                categoryAdded.Remove(c);
            }
            CatChange = CompareCatList(categoryAdded, cat);
        }
        private bool CompareCatList(List<CategoryProxy> copyList, List<CategoryProxy> mainList)
        {
            bool change = false;
            foreach(CategoryProxy c in copyList)
            {
                if (!mainList.Contains(c))
                    change = true;
            }
            if (copyList.Count == 0 || copyList.Count != mainList.Count)
                change = true;
            return change;
        }
        private bool catChange;
        private bool CatChange
        {
            get
            {
                return catChange;
            }
            set
            {
                catChange = value;
                RaisePropertyChanged(nameof(CatChange));
            }
        }
        public bool IsMemeber
        {
            get => App.CurrentUser.Role == Role.Member;
        }
        public bool IsNotMemeber
        {
            get => App.CurrentUser.Role == Role.Admin;
        }
        public BookDetailView(Book book, bool isNew) //Constructeur
        {
            InitializeComponent();

            DataContext = this;
            Book = book;
            IsNew = isNew;
            imageHelper = new ImageHelper(App.IMAGE_PATH, Book.PicturePath);

            App.Register(this, AppMessage.MSG_BASKET_UPDATED, () => { RaisePropertyChanged(nameof(BookCopies)); });
            App.Register(this, AppMessage.MSG_CATEGORIES_UPDATED, () => { RaisePropertyChanged(nameof(CategoriesList)); });
            App.Register<Book>(this, AppMessage.MSG_BOOK_CHANGED, (b) => { RaisePropertyChanged(nameof(BookCopies)); });
            //Sauvegarde Traitement
            Save = new RelayCommand(SaveAction, CanSaveOrCancelAction);
            Cancel = new RelayCommand(CancelAction, CanSaveOrCancelAction);
            Delete = new RelayCommand(DeleteAction, () => !IsNew);
            LoadImage = new RelayCommand(LoadImageAction);
            ClearImage = new RelayCommand(ClearImageAction, () => PicturePath != null);
            AddCopies = new RelayCommand(AddAction,()=> { return !HasErrors; });
            Check = new RelayCommand<CategoryProxy>((c) => { CheckCat(c); });
        }

        public override bool Validate()
        {
            ClearErrors();
            //ISBN
            var isbn = App.Model.Books.Where((c) => c.Isbn == Isbn).FirstOrDefault();
            if (string.IsNullOrEmpty(Isbn))
            {
                AddError("Isbn", Properties.Resources.Error_Required);
            }
            else
            {
                if (Isbn.Length < 3)
                {
                    AddError("Isbn", Properties.Resources.Error_LengthGreaterEqual3);
                }
                else
                {
                    if (isbn != null && App.Model.BookOfIsbn(Isbn) != Book)
                    {
                        AddError("Isbn", Properties.Resources.Error_NotAvailable);
                    }
                }
            }
            //Title
            if (string.IsNullOrEmpty(Title))
            {
                AddError("Title", Properties.Resources.Error_Required);
            } else
            {
                if(Title.Length < 3)
                {
                    AddError("Title", Properties.Resources.Error_LengthGreaterEqual3);
                }
                else
                {
                    if(Title.Length > 35)
                    {
                        AddError("Title", Properties.Resources.Error_LengthLess35);
                    }
                }
            }
            //Author
            if (string.IsNullOrEmpty(Author))
            {
                AddError("Author", Properties.Resources.Error_Required);
            }
            else
            {
                if (Author.Length < 3)
                {
                    AddError("Author", Properties.Resources.Error_LengthGreaterEqual3);
                }
                else
                {
                    if (Author.Length > 35)
                    {
                        AddError("Author", Properties.Resources.Error_LengthLess35);
                    }
                }
            }
            //Editor
            if (string.IsNullOrEmpty(Editor))
            {
                AddError("Editor", Properties.Resources.Error_Required);
            }
            else
            {
                if (Editor.Length < 3)
                {
                    AddError("Editor", Properties.Resources.Error_LengthGreaterEqual3);
                }
                else
                {
                    if (Editor.Length > 35)
                    {
                        AddError("Editor", Properties.Resources.Error_LengthLess35);
                    }
                }
            }
            RaiseErrors();
            return !HasErrors;
        }

    }
}

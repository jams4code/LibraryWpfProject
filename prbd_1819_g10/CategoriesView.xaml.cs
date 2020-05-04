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
    /// Logique d'interaction pour CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControlBase
    {
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories {
            get => new ObservableCollection<Category>(App.Model.Categories.OrderBy(c=>c.Name));
            set => SetProperty<ObservableCollection<Category>>(ref categories, value);
        }
        private Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                SetProperty<Category>(ref selectedCategory, value);
                CategoryName = SelectedCategory?.Name;
                RaisePropertyChanged(nameof(CategoryName));

            }
        }
        private bool changed = false;
        public bool Changed {
            get => changed;
            set => changed = value;
        }
        public bool IsAdmin
        {
            get => App.CurrentUser.Role == Role.Admin;
        }
        public bool IsNotAdmin
        {
            get => App.CurrentUser.Role != Role.Admin;
        }
        private String categoryName;
        public String CategoryName {
            get {
                return categoryName; 
            }
            set {
                categoryName = value;
                if (categoryName != selectedCategory?.Name)
                    Changed = true;
                if (CategoryName == null || CategoryName == String.Empty || categoryName == selectedCategory?.Name || Categories.Any((c) => c.Name == categoryName.Trim()))
                {
                    Changed = false;
                }
            }
        }
        public ICommand Add{ get; set; }
        public void AddCategory() {

                App.Model.CreateCategory(categoryName);
                App.Model.SaveChanges();
                CategoryName = "";
                App.NotifyColleagues(AppMessage.MSG_CATEGORIES_UPDATED);
                RaisePropertyChanged(nameof(Categories));
                RaisePropertyChanged(nameof(SelectedCategory));
        }
        public ICommand Update { get; set; }
        public void UpdateCategory() {
            selectedCategory.Name = categoryName;
            RaisePropertyChanged(nameof(CategoryName));
            App.Model.SaveChanges();
            App.NotifyColleagues(AppMessage.MSG_CATEGORIES_UPDATED);
            notifyAll();
        }
        public ICommand Delete { get; set; }
        public void DeleteCategory() {
            var result = MessageBox.Show("Voulez vous supprimer cette categorie ?", "message confirmation suppression", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                SelectedCategory.Delete();
                SelectedCategory = null;
                App.NotifyColleagues(AppMessage.MSG_CATEGORIES_UPDATED);
                RaisePropertyChanged(nameof(Categories));
            }


        }
        public ICommand Cancel { get; set; }
        public void CancelMove() {
            CategoryName = "";
            if (SelectedCategory != null)
                CategoryName = selectedCategory.Name;

            RaisePropertyChanged(nameof(CategoryName));
        }
        public CategoriesView()
        {
            InitializeComponent();
            DataContext = this;
            Add = new RelayCommand(AddCategory,()=> { return Changed; });
            Update = new RelayCommand(UpdateCategory, () => { return Changed; });
            Cancel = new RelayCommand(CancelMove, () => { return Changed; });
            Delete = new RelayCommand(DeleteCategory);
            App.Register(this,AppMessage.MSG_CATEGORIES_UPDATED,()=> { notifyAll();});
            App.Register<Book>(this, AppMessage.MSG_BOOK_CHANGED, (b) => { notifyAll(); });
            App.Register<Book>(this, AppMessage.MSG_BOOK_DELETED, (b) => { notifyAll(); });
        }
        public void notifyAll()
        {
            RaisePropertyChanged(nameof(CategoryName));
            RaisePropertyChanged(nameof(Categories));
            RaisePropertyChanged(nameof(SelectedCategory));
        }
    }
}

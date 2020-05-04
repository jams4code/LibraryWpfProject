using PRBD_Framework;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class MainView : WindowBase
    {
        public ICommand LogOut { get; set; }
        public MainView()
        {
            InitializeComponent();
            DataContext = this;
            // Bouton New Book
            App.Register(this, AppMessage.MSG_NEW_BOOK, () =>
            {
                //Créer une nouvelle instance de Livre
                var book = App.Model.Books.Create();
                AddTabBook(book, true);
            });

            //New ISBN assigne la nouvelle valeur de l'ISBN lorsque celle ci est inséré lors d'un new BOOK
            App.Register<String>(this, AppMessage.MSG_ISBN_CHANGED, (s) =>
            {
                (tabControl.SelectedItem as TabItem).Header = s;
            });

            App.Register<Book>(this, AppMessage.MSG_DISPLAY_BOOK, (book) => {
                if (book != null)
                {
                    var tab = (from TabItem t in tabControl.Items where (string)t.Header == book.Isbn select t).FirstOrDefault();
                    if (tab == null)
                        AddTabBook(book, false);
                    else
                        Dispatcher.InvokeAsync(() => tab.Focus());
                }
            });
            App.Register<Book>(this,AppMessage.MSG_BOOK_DELETED,(book) => {
                if (book != null)
                {
                    var tab = (from TabItem t in tabControl.Items where (string)t.Header == book.Isbn select t).FirstOrDefault();
                    tabControl.Items.Remove(tab);
                }
            });
            LogOut = new RelayCommand(()=> {
                var loginView = new LoginView();
                loginView.Show();
                Application.Current.MainWindow = loginView;
                Close();
            });
        }
        private void AddTabBook(Book book, bool isNew)
        {
            var ctl = new BookDetailView(book, isNew);
            var tab = new TabItem()
            {
                Header = isNew ? "<new member>" : book.Isbn,
                Content = ctl
            };
            tab.MouseDown += (o, e) => {
                if (e.ChangedButton == MouseButton.Middle &&
                    e.ButtonState == MouseButtonState.Pressed)
                {
                    tabControl.Items.Remove(o);
                    (tab.Content as UserControlBase).Dispose();
                }
            };
            tab.PreviewKeyDown += (o, e) => {
                if (e.Key == Key.W && Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    tabControl.Items.Remove(o);
                    (tab.Content as UserControlBase).Dispose();
                }
            };
            // ajoute ce onglet à la liste des onglets existant du TabControl
            tabControl.Items.Add(tab);
            // exécute la méthode Focus() de l'onglet pour lui donner le focus (càd l'activer)
            Dispatcher.InvokeAsync(() => tab.Focus());
        }
    }
}

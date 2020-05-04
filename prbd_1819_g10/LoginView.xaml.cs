using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class LoginView : WindowBase
    {
        private string userName;
        public string UserName { get => userName; set => SetProperty<string>(ref userName, value, () => Validate()); }

        private string password;
        public string Password { get => password; set => SetProperty<string>(ref password, value, () => Validate()); }

        public ICommand Login { get; set; }
        public ICommand Cancel { get; set; }

        public LoginView()
        {
            InitializeComponent();
            if (DesignerProperties.GetIsInDesignMode(this))

                return;
            DataContext = this;

            Login = new RelayCommand(LoginAction, () => {  return userName != null && password != null && !HasErrors; });
            Cancel = new RelayCommand(() => Close());
        }

        private void LoginAction()
        {
            if (Validate())
            { // si aucune erreurs
                var user = App.Model.Users.Where((c) => c.UserName == UserName).FirstOrDefault(); // on recherche le user 
                App.CurrentUser = user; // le membre connecté devient le membre courant
                ShowMainView(); // ouverture de la fenêtre principale
                Close(); // fermeture de la fenêtre de login
            }
        }

        private static void ShowMainView()
        {
            var mainView = new MainView();
            mainView.Show();
            Application.Current.MainWindow = mainView;
        }

        public override bool Validate()
        {
            ClearErrors();
            var user = App.Model.Users.Where((c) => c.UserName == UserName).FirstOrDefault();
            if (string.IsNullOrEmpty(UserName))
            {
                AddError("Username", Properties.Resources.Error_Required);
            }
            else
            {
                if (UserName.Length < 3)
                {
                    AddError("Username", Properties.Resources.Error_LengthGreaterEqual3);
                }
                else
                {
                    if (user == null)
                    {
                        AddError("Username", Properties.Resources.Error_DoesNotExist);
                    }
                }
            }
            if (string.IsNullOrEmpty(Password))
            {
                AddError("Password", Properties.Resources.Error_Required);
            }
            else
            {
                if (Password.Length < 3)
                {
                    AddError("Password", Properties.Resources.Error_LengthGreaterEqual3);
                }
                else if (user != null && user.Password != Password)
                {
                    AddError("Password", Properties.Resources.Error_WrongPassword);
                }
            }
            RaiseErrors();
            return !HasErrors;
        }
    }
}

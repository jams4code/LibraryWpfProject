using prbd_1819_g10.Properties;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace prbd_1819_g10
{
    public enum AppMessage
    {
        MSG_NEW_BOOK,
        MSG_DISPLAY_BOOK,
        MSG_ISBN_CHANGED,
        MSG_BOOK_CHANGED,
        MSG_CLOSE_TAB,
        MSG_BOOKCOPIES_ADDED,
        MSG_CATEGORIES_UPDATED,
        MSG_BASKET_UPDATED,
        MSG_BOOK_DELETED,
        MSG_USER_CHANGED
    }
    public partial class App : ApplicationBase
    {
        
#if MSSQL
        private static DbType type = DbType.MsSQL;
        private readonly bool isMsSql = true;
#else
        private static DbType type = DbType.MySQL;
        private bool isMsSql = false;
#endif
        public static Model Model { get; } = Model.CreateModel(type);
        public static User CurrentUser { get; set; }
        public static readonly string IMAGE_PATH = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/../../images");
        public App()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Culture);
            ColdStart();
#if MSSQL
                Model.CreateTestDataMs();
#else
                Model.CreateTestDataMy();
#endif
        }
        private void ColdStart()
        {
            Model.Users.Where(c=>c.UserName=="cacola");

        }

    }
    
}

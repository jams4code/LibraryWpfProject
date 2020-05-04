using MySql.Data.EntityFramework;
using System;
using System.Linq;
using System.Data.Entity;
using prbd_1819_g10;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;

namespace prbd_1819_g10 {
    public enum DbType { MsSQL, MySQL }
    public enum EFDatabaseInitMode { CreateIfNotExists, DropCreateIfChanges, DropCreateAlways }

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlModel : Model {
        public MySqlModel(EFDatabaseInitMode initMode) : base("name=library-mysql") {
            switch (initMode) {
                case EFDatabaseInitMode.CreateIfNotExists:
                    Database.SetInitializer<MySqlModel>(new CreateDatabaseIfNotExists<MySqlModel>());
                    break;
                case EFDatabaseInitMode.DropCreateIfChanges:
                    Database.SetInitializer<MySqlModel>(new DropCreateDatabaseIfModelChanges<MySqlModel>());
                    break;
                case EFDatabaseInitMode.DropCreateAlways:
                    Database.SetInitializer<MySqlModel>(new DropCreateDatabaseAlways<MySqlModel>());
                    break;
            }
        }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // see: https://blog.craigtp.co.uk/Post/2017/04/05/Entity_Framework_with_MySQL_-_Booleans,_Bits_and_%22String_was_not_recognized_as_a_valid_boolean%22_errors.
            modelBuilder.Properties<bool>().Configure(c => c.HasColumnType("bit"));
        }

        public override void Reseed(string tableName) {
            Database.ExecuteSqlCommand($"ALTER TABLE {tableName} AUTO_INCREMENT=1");
        }
    }
    public class EntityBase<T> where T : DbContext
    {
        private static DbContext GetDbContextFromEntity(object entity)
        {
            var object_context = GetObjectContextFromEntity(entity);
            if (object_context == null || object_context.TransactionHandler == null)
            {
                return null;
            }
            return object_context.TransactionHandler.DbContext;
        }
        private static ObjectContext GetObjectContextFromEntity(object entity)
        {
            var field = entity.GetType().GetField("_entityWrapper");
            if (field == null)
            {
                return null;
            }
            var wrapper = field.GetValue(entity);
            if (wrapper == null)
            {
                return null;
            }
            var property = wrapper.GetType().GetProperty("Context");
            if (property == null)
            {
                return null;
            }
            var context = (ObjectContext)property.GetValue(wrapper, null);
            return context;
        }
        private T _model = null;
        public bool Attached { get { return Model != null; } }
        public bool Detached { get { return Model == null; } }
        public T Model
        {
            get
            {
                if (_model == null)
                {
                    _model = (T)GetDbContextFromEntity(this);
                }
                return _model;
            }
        }
    }
    public class MsSqlModel : Model {
        public MsSqlModel(EFDatabaseInitMode initMode) : base("name=library-mssql") {
            switch (initMode) {
                case EFDatabaseInitMode.CreateIfNotExists:
                    Database.SetInitializer<MsSqlModel>(new CreateDatabaseIfNotExists<MsSqlModel>());
                    break;
                case EFDatabaseInitMode.DropCreateIfChanges:
                    Database.SetInitializer<MsSqlModel>(new DropCreateDatabaseIfModelChanges<MsSqlModel>());
                    break;
                case EFDatabaseInitMode.DropCreateAlways:
                    Database.SetInitializer<MsSqlModel>(new DropCreateDatabaseAlways<MsSqlModel>());
                    break;
            }
        }

        public override void Reseed(string tableName) {
            Database.ExecuteSqlCommand($"DBCC CHECKIDENT('{tableName}', RESEED, 0)");
        }
    }

    public abstract class Model : DbContext {
        protected Model(string name) : base(name) { }

        public static Model CreateModel(DbType type, EFDatabaseInitMode initMode = EFDatabaseInitMode.DropCreateIfChanges) {
            switch (type) {
                case DbType.MsSQL:
                    return new MsSqlModel(initMode);
                case DbType.MySQL:
                    return new MySqlModel(initMode);
                default:
                    throw new ApplicationException("Undefined database type");
            }
        }
        
        //--------------------------------------------------------------------------------------
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalItem> RentalItems { get; set; }
        //------------------------   A Mettre à jour -------------------------------------------------------------------- !!
        public void ClearDatabase() {
            Users.RemoveRange(Users.Include(nameof(User.Rentals)));
            Rentals.RemoveRange(Rentals.Include(nameof(Rental.Items)));
            Books.RemoveRange(Books.Include(nameof(Book.Copies)).Include(nameof(Book.Categories)));
            Categories.RemoveRange(Categories.Include(nameof(Category.Books)));
            BookCopies.RemoveRange(BookCopies.Include(nameof(BookCopy.RentalItems)));
            RentalItems.RemoveRange(RentalItems);
            Reseed(nameof(Users));
            Reseed(nameof(Rentals));
            Reseed(nameof(Books));
            Reseed(nameof(Categories));
            Reseed(nameof(BookCopies));
            Reseed(nameof(RentalItems));
            this.SaveChanges();

        }

        public abstract void Reseed(string tableName);

        public void CreateTestDataMs() {
            TestDatas ts = new TestDatas(DbType.MsSQL);
            ts.Run();
        }
        public void CreateTestDataMy()
        {
            TestDatas ts = new TestDatas(DbType.MySQL);
            ts.Run();
        }
        public User CreateUser(String userName, String password, String fullName, String email, DateTime? birthdate = null, Role role = Role.Member){
            var user = Users.Create();
            user.UserName = userName;
            user.Password = password;
            user.FullName = fullName;
            user.Email = email;
            user.BirthDate = birthdate;
            user.Role = role;
            Users.Add(user);
            return user;
        }    
        public Book CreateBook(String isbn, String title, String author, String editor,int numCopies = 1){
            var book = Books.Create();
            book.Isbn = isbn;
            book.Title = title;
            book.Author = author;
            book.Editor = editor;
            DateTime n = DateTime.Now;
            Books.Add(book);
            book.AddCopies(numCopies, n);
            return book;
        }
        public Category CreateCategory(String name){
            var cat = Categories.Create();
            cat.Name = name;
            Categories.Add(cat);
            return cat;
        }
        public List<Book> FindBooksByText(String key){
            return (from c in this.Books where c.Isbn.Contains(key)||c.Title.Contains(key)
                            ||c.Author.Contains(key)||c.Editor.Contains(key) select c).ToList();
        }
        public Book BookOfIsbn(string isbn) {
            return (
                 from book in this.Books
                 where book.Isbn.Equals(isbn)
                 select book
                ).SingleOrDefault();
        }
        public List<RentalItem> GetActiveRentalItems(){
            return (from c in this.RentalItems where c.ReturnDate == null select c).ToList();
        }
    }
}

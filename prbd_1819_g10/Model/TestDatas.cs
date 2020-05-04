using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prbd_1819_g10;

namespace prbd_1819_g10
{
    class TestDatas
    {
        private readonly DbType dbType;

        private Model model;

        private User admin, manager, jamal, mehdi;
        private List<User> users = new List<User>();

        private Category catInformatique, catScienceFiction, catRoman, catLitterature, catEssai, catOther;
        private List<Category> categories = new List<Category>();

        private Book book1, book2, book3, book4, book5, book6, book7, book8;
        private List<Book> books = new List<Book>();

        public TestDatas(DbType dbType)
        {
            this.dbType = dbType;
        }

        public void Run()
        {
            using (model = Model.CreateModel(dbType))
            {
                bool isInit = App.Model.Users.Where((c) => c.UserName == "admin").Count() > 0;
                if (!isInit)
                    CreateEntities(model);
                else
                    Console.WriteLine("Database already init");
            }
        }

        private void CreateEntities(Model model)
        {
            Console.WriteLine("Init database");
            CreateUsers();
            CreateCategories();
            CreateBooks();
        }

        private void CreateUsers()
        {
            admin = model.CreateUser("admin", "admin", "Administrator", "admin@test.com", role: Role.Admin);
            manager = model.CreateUser("manager", "manager", "the manager", "manager@test.com", new DateTime(1968, 10, 1), role: Role.Manager);
            jamal = model.CreateUser("jamal", "jamal", "Jamal Abdelkhalek", "jamal@test.com", new DateTime(1997, 05, 28));
            mehdi = model.CreateUser("mehdi", "mehdi", "Mehdi Pexcigor", "mehdi@test.com");
            users.AddRange(new User[] { admin, manager, jamal, mehdi });
        }

        private void CreateCategories()
        {
            catInformatique = model.CreateCategory("Informatique");
            catScienceFiction = model.CreateCategory("Science Fiction");
            catRoman = model.CreateCategory("Roman");
            catLitterature = model.CreateCategory("Littérature");
            catEssai = model.CreateCategory("Essai");
            catOther = model.CreateCategory("Other");
            categories.AddRange(new Category[] { catInformatique, catScienceFiction, catRoman, catLitterature, catEssai, catOther});
        }

        private void CreateBooks()
        {
            book1 = model.CreateBook(
                isbn: "123",
                title: "Java for Dummies",
                author: "Duchmol",
                editor: "EPFC",
                numCopies: 10);
            book1.PicturePath = "123.jpg";
            book2 = model.CreateBook(
                isbn: "456",
                title: "Le Seigneur des Anneaux",
                author: "Tolkien",
                editor: "Bourgeois",
                numCopies: 10);
            book2.PicturePath = "456.jpg";
            book3 = model.CreateBook(
                isbn: "789",
                title: "Les misérables",
                author: "Victor Hugo",
                editor: "XO",
                numCopies: 10);
            book3.PicturePath = "789.jpg";
            book4 = model.CreateBook(
                isbn: "124",
                title: "Educated: A Memoir",
                author: "Tara Westover",
                editor: "Random House",
                numCopies: 10);
            book4.PicturePath = "edu.jpg";
            book5 = model.CreateBook(
                isbn: "125",
                title: "Pere Riche Pere Pauvre",
                author: "Robert T. Kiyosaki",
                editor: "Plata Publishing",
                numCopies: 10);
            book5.PicturePath = "pereRiche.jpg";
            book6 = model.CreateBook(
                isbn: "126",
                title: "Les jumeaux de Piolenc",
                author: "Sandrine Destombes",
                editor: "Hugo Roman",
                numCopies: 10);
            book6.PicturePath = "jum.jpg";
            book7 = model.CreateBook(
                isbn: "127",
                title: "UML au service de l'analyse des métiers",
                author: "Antoine Clave",
                editor: "Eni Editions",
                numCopies: 10);
            book7.PicturePath = "uml.jpg";
            book8 = model.CreateBook(
                isbn: "128",
                title: "CRM analytique",
                author: "Philippe Nieuwbourg",
                editor: "Marcom Generation",
                numCopies: 1);
            book8.PicturePath = "118.jpg";
            books.AddRange(new Book[] { book1, book2, book3, book4, book5, book6, book7, book8});
        }
    }
}

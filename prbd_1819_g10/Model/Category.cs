using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_1819_g10
{
    public class Category : EntityBase<Model>
    {
        [Key]
        public int CategoryId { get; set; }
        public String Name { get; set; }

        public virtual ICollection<Book> Books{ get; set; } = new HashSet<Book>();

        protected Category() { }

        public bool HasBook(Book book)
        {
            if(book != null)
            {
                var b = (from c in Model.Books where book.BookId == c.BookId && book.Title == c.Title select c).FirstOrDefault();
                return b.Categories.Contains(this) && Books.Contains(b);
            }
            return false;
        }

        public void AddBook(Book book)
        {
            if (!Books.Contains(book))
            {
                this.Books.Add(book);
                book.AddCategory(this);
            }
            Model.SaveChanges();

        }

        public void RemoveBook(Book book)
        {
            if (Books.Contains(book))
            {
                this.Books.Remove(book);
                book.RemoveCategory(this);
            }
            Model.SaveChanges();
        }

        public void Delete()
        {
            var BooksIt = new HashSet<Book>(Books); 
            foreach (Book b in BooksIt)
            {
                 b.RemoveCategory(this);
            }
            Model.Categories.Remove(this);
            Model.SaveChanges();
        }
        public int NbBooks {
            get => Books.Count();
        }

    }
    public class CategoryProxy
    {
        private Category cat;
        private Boolean isChecked;
        public CategoryProxy(Category c, Boolean isCheck)
        {
            cat = c;
            isChecked = isCheck;
        }
        public bool IsChecked { get => isChecked; set => isChecked = value; }
        public Category Cat { get => cat; }
        public static List<CategoryProxy> FullCatList()
        {
            List<CategoryProxy> cat = new List<CategoryProxy>();
            foreach (Category c in App.Model.Categories)
            {
                cat.Add(new CategoryProxy(c, false));
            }
            return cat;
        }
    }
}

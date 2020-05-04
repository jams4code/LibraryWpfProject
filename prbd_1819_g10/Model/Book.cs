using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prbd_1819_g10;

namespace prbd_1819_g10
{
    public class Book : EntityBase<Model>
    {
        [Key]
        public int BookId { get; set; }
        public String Isbn { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public String Editor { get; set; }
        public String PicturePath{ get; set; }
        public int NumAvailableCopies { get { return (
                    from c in this.Model.BookCopies
                    where c.Book.BookId == BookId &&
                    (from i in c.RentalItems where i.ReturnDate == null select i).Count() == 0
                    select c
                ).Count(); } }
        public int NumAvailableCopiess
        {
            get
            {
                return (from c in Model.BookCopies
                        where c.Book.BookId == BookId && (from i in c.RentalItems where i.Rental.User == null select i).Count() == 0 select c).Count();
            }
        }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<BookCopy> Copies { get; set; } = new HashSet<BookCopy>();

        [NotMapped]
        public string AbsolutePicturePath
        {
            get { return PicturePath != null ? App.IMAGE_PATH + "\\" + PicturePath : null; }
        }

        protected Book() { }

        public void AddCategory(Category category)
        {
            if (!Categories.Contains(category))
            {
                category.AddBook(this);
                Categories.Add(category);
                Model.SaveChanges();
            }
        }

        public void RemoveCategory(Category category)
        {
            if (Categories.Contains(category))
            {
                Categories.Remove(category);
                category.RemoveBook(this);
                Model.SaveChanges();
            }
        }

        public void AddCopies(int quantity, DateTime date)
        {
            for (int i = 0; i < quantity; i++)
            {
                
                var BookCopy = Model.BookCopies.Create();
                BookCopy.Book = this;
                BookCopy.AcquisitionDate = date;
                Copies.Add(BookCopy);
                Model.BookCopies.Add(BookCopy);
            }
            Model.SaveChanges();
        }

        public BookCopy GetAvailableCopy()
        {
            return (
                    from c in this.Model.BookCopies
                    where c.Book.BookId == BookId &&
                    (from i in c.RentalItems where i.ReturnDate == null select i).Count() == 0
                    select c
                ).FirstOrDefault();
        }

        public void DeleteCopy(BookCopy copy)
        {
            var bookCopy = (from c in Model.BookCopies where c.Book.BookId == BookId select c);
            Copies.Remove(copy);
            Model.SaveChanges();
        }

        public void Delete()
        {
            var rentalItem = (from c in Model.RentalItems where this.BookId == c.BookCopy.Book.BookId select c).ToArray();
            Model.RentalItems.RemoveRange(rentalItem);
            Model.Books.Remove(this);
            Model.SaveChanges();
        }
        
        public void AddCategories(Category[] categories) {
            foreach (Category Cat in categories) {
                AddCategory(Cat);
               
            }
         }
        public void RemoveCategories(Category[] categories)
        {
            foreach (Category Cat in categories)
            {
                RemoveCategory(Cat);
            }
        }
    }
}

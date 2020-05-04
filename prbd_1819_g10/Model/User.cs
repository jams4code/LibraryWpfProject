using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_1819_g10
{
    public class User : EntityBase<Model>
    {
        [Key]
        public int UserId { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public Role Role { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

        [NotMapped]
        public Rental Basket { get { return (from c in Model.Rentals where c.RentalDate == null && c.User.UserId == this.UserId select c).FirstOrDefault(); }  }

        [NotMapped]
        public RentalItem[] ActiveRentalItems { get { return (from c in Model.RentalItems where c.Rental.User.UserId == this.UserId && c.ReturnDate == null select c).ToArray();
            } }
        public int Age { get { return CalculateAge(); }}
        protected User() { }
        private int CalculateAge() {
            DateTime now = DateTime.Now;
            int age = -1;
            if (BirthDate.HasValue
) {
                DateTime bd = BirthDate.Value;
                age = (int)now.Subtract(bd).TotalDays / 365;
            }
            return age;
        }
        public Rental CreateBasket() {
            var basket = Model.Rentals.Create();
            basket.User = this;
            Rentals.Add(basket);
            Model.Rentals.Add(basket);
            Model.SaveChanges();
            return basket;
        }
        public RentalItem AddToBasket(Book book) {
            BookCopy cp = book.GetAvailableCopy();
            RentalItem Rented = null;
            if (Basket == null){
                this.CreateBasket();
            }
            if (cp != null) {
                Rented = Basket.RentCopy(cp);
            }
            return Rented;
        }
        public void RemoveFromBasket(RentalItem item) {
            Basket.RemoveItem(item);
        }
        public void RemoveFromBasket(Book item)
        {
            RentalItem it = (from c in Basket.Items where c.BookCopy.Book.BookId == item.BookId select c).FirstOrDefault();
            RemoveFromBasket(it);
        }
        public void ClearBasket() {
            if(Basket != null)
                Basket.ClearItems();
        }
    }
    public enum Role
    {
        Admin,
        Member,
        Manager,
    }
}

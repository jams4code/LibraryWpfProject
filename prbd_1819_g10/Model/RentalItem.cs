using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace prbd_1819_g10
{
    public class RentalItem : EntityBase<Model>
    {
        [Key]
        public int RentalItemId { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual BookCopy BookCopy { get; set; }
        public virtual Rental Rental { get; set; }
        public RentalItem() { }

        public void DoReturn()
        {
            ReturnDate = DateTime.Now;
            Model.SaveChanges();
        }

        public Boolean CancelReturn()
        {
            var bc = BookCopy.Book.GetAvailableCopy();
            if (bc != null)
            {
                ReturnDate = null;
                this.BookCopy = bc;
                Model.SaveChanges();
            }
            return bc != null; 
        }
        public string TitleBook {
            get => BookCopy.Book.Title;
        }

    }
    public class RentalItemProxy
    {
        private RentalItem rentalItem;
        public RentalItem RentalItem { get => rentalItem; }
        public RentalItemProxy(RentalItem ri)
        {
            rentalItem = ri;
        }
        public Boolean IsReturned { get =>rentalItem.ReturnDate != null;}
        public Boolean IsNotReturned { get => rentalItem.ReturnDate == null; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_1819_g10
{
    public class BookCopy : EntityBase<Model>
    {
        [Key]
        public int BookCopyId { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public virtual User RentedBy { get { return (from c in App.Model.RentalItems where c.BookCopy.BookCopyId == this.BookCopyId && c.ReturnDate == null select c.Rental.User).FirstOrDefault(); } }

        //Liaison missing public virtual ... avec book et rentalItems
        [Required]
        public Book Book { get; set; }
        public virtual ICollection<RentalItem> RentalItems { get; set; } = new HashSet<RentalItem>();
        protected BookCopy() { }
        override
        public string ToString() {
            return Book.Title;
        }
        public string NameRenter {
            get => RentedBy.UserName;
        }
        public int nbRIt {
            get => RentalItems.Count();
        }
    }
}

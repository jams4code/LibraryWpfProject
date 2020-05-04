using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_1819_g10
{
    public class Rental : EntityBase<Model>
    {
        [Key]
        public int RentalId { get; set; }
        public DateTime? RentalDate { get; set; }
        public int NumOpenItems { get { return (from c in Model.RentalItems where c.Rental.RentalId == this.RentalId && c.ReturnDate == null select c).ToArray().Count(); } }

        //Liaison missing public virtual ... Items et User
        public virtual ICollection<RentalItem> Items { get; set; } = new HashSet<RentalItem>();
        public virtual User User { get; set; }

        protected Rental() { }

        public RentalItem RentCopy(BookCopy copy)
        {
            var rentalit = Model.RentalItems.Create();
            rentalit.BookCopy = copy;
            rentalit.Rental = this;
            Items.Add(rentalit);
            Model.RentalItems.Add(rentalit);
            Model.SaveChanges();
            return rentalit;
        }

        public BookCopy RemoveCopy(BookCopy copy)
        {
            RentalItem ToRemove = null;
            foreach (RentalItem it in Items) {
                if (it.BookCopy == copy) {
                    ToRemove = it;
                }
            }
            Model.RentalItems.Remove(ToRemove);
            Model.SaveChanges();
            return copy;

        }
        public void RemoveItem(RentalItem item)
        {
            if (Items.Contains(item)) {
                Model.RentalItems.Remove(item);
            }
            Model.SaveChanges();
        }

        public void Return(RentalItem Item)
        {
            RentalItem ToReturn = null;
            foreach (RentalItem it in Items)
            {
                if (it == Item)
                {
                    ToReturn = it;
                }
            }
            if (ToReturn != null)
                ToReturn.DoReturn();
            Model.SaveChanges();

        }

        public void Confirm()
        {
            RentalDate = DateTime.Now;
            Model.SaveChanges();
        }
        public int NbItems {
            get=> Items.Count();
        }

        public void ClearItems()
        {          
            Model.RentalItems.RemoveRange(Items);
            Model.SaveChanges();
        }
        override
        public string ToString() {
            return this.RentalId+"";
        }
    }
}

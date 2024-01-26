using System.ComponentModel.DataAnnotations.Schema;

namespace BBP.Model
{
    public class Stock
    {
        public int Id { get; set; }

        public int BeerId { get; set; }
        public int WholesalerId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(BeerId))]
        public virtual Beer? Beer { get; set; }

        [ForeignKey(nameof(WholesalerId))]
        public virtual Wholesaler? Wholesaler { get; set; }
    }
}
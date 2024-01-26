using System.ComponentModel.DataAnnotations;

namespace BBP.Dto
{
    public class StockForUpdateDto
    {
        public int BeerId { get; set; }
        public int? WholesalerId { get; set; }

        public int Quantity { get; set; }

    }
    
}
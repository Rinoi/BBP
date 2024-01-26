using System.ComponentModel.DataAnnotations;

namespace BBP.Dto
{
    public class StockDto
    {
    public int BeerId { get; set; }
    public int WholesalerId { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être un nombre positif.")]
    public int Quantity { get; set; }
    }
}
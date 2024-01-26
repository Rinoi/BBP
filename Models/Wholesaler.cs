
namespace BBP.Model
{
    public class Wholesaler
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Propriété de navigation pour les stocks du grossiste
        public virtual IEnumerable<Stock>? Stocks { get; set; }
    }
}
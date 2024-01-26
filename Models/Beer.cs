using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBP.Model
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        [Range(0, 100, ErrorMessage = "La teneur en alcool doit être comprise entre 0 et 100.")]
        public double AlcoholPercentage { get; set; }
        public double Price { get; set; }
        public int BreweryId { get; set; }

        [ForeignKey(nameof(BreweryId))]
        public virtual Brewery? Brewery { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace BBP.Model
{
        public class Brewery
        {
                public int Id { get; set; }
                public string? Name { get; set; }

                [InverseProperty(nameof(Beer.Brewery))]
                public virtual ICollection<Beer>? Beers { get; set; }
        }
}
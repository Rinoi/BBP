using System.ComponentModel.DataAnnotations;
using BBP.Model;

namespace BBP.Dto
{
    public class BreweryForDisplayDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual IEnumerable<BeerForDisplayDto>? Beers { get; set; }

        static public BreweryForDisplayDto FromBrewery(Brewery brewery, bool proliferate = true)
        {
            BreweryForDisplayDto dto = new BreweryForDisplayDto
            {
                Id = brewery.Id,
                Name = brewery.Name,
                Beers = proliferate == true ? brewery.Beers?.Select(b => BeerForDisplayDto.FromBeer(b, null, false)) : null
            };
            return dto;
        }
    }

}
namespace BBP.Dto
{
    public class BeerForCreationDto
    {
        public string? Name { get; set; }
        public double AlcoholPercentage { get; set; }
        public double Price { get; set; }
        public int BreweryId { get; set; }
    }
}
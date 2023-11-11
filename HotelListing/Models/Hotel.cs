using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Models;

public class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Adress { get; set; } = string.Empty;

    public double Raiting { get; set; }

    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }

    public Country Country { get; set; } = null!;
}

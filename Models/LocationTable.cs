using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    public class Location
{
    public int Id { get; set; }

    public int LookupFacilityLocId { get; set; }

    public string? FacType { get; set; } // Nullable
    public string? FacilityLocation { get; set; } // Nullable
    public string? ServiceArea { get; set; } // Nullable
    public string? Region { get; set; } // Nullable
    public string? City { get; set; } // Nullable
    public string? State { get; set; } // Nullable
    public string? CCC { get; set; } // Nullable
    public string? SSC { get; set; } // Nullable
    public string? SDPFacType { get; set; } // Nullable
    public string? SDPLocID { get; set; } // Nullable
    public string? Airport { get; set; } // Nullable
    public string? AirportCode { get; set; } // Nullable
    public string? Tier { get; set; } // Nullable
    public string? Runway { get; set; } // Nullable
}
}


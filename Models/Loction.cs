using System.ComponentModel.DataAnnotations;

public class Location
{
    [Key]
    public int Id { get; set; }
    public string FacType { get; set; }
    public string LocID { get; set; }
    public string ServiceArea { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string CCC { get; set; }
    public string SSC { get; set; }
    public string SDPFacType { get; set; }
    public string SDPLocID { get; set; }
    public string Airport { get; set; }
}

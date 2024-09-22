using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    public class Location
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("lookup_facility_loc_id")]
        public int LookupFacilityLocId { get; set; }

        [Column("fac_type")]
        public string FacType { get; set; }

        [Column("facility_location")]
        public string FacilityLocation { get; set; }

        [Column("service_area")]
        public string ServiceArea { get; set; }

        [Column("region")]
        public string Region { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("state")]
        public string State { get; set; }

        [Column("city_1")]
        public string City1 { get; set; }

        [Column("cost_center_code")]
        public string CostCenterCode { get; set; }

        [Column("system_support_center")]
        public string SystemSupportCenter { get; set; }

        [Column("sdp_fac_type")]
        public string SdpFacType { get; set; }

        [Column("sdp_facility_location")]
        public string SdpFacilityLocation { get; set; }

        [Column("tech_ops_district_office")]
        public string TechOpsDistrictOffice { get; set; }

        [Column("district_office_group")]
        public string DistrictOfficeGroup { get; set; }

        [Column("airport_code")]
        public string? AirportCode { get; set; } // Nullable

        [Column("tier")]
        public string Tier { get; set; }

        [Column("runway")]
        public string? Runway { get; set; }  // Nullable
    }
}

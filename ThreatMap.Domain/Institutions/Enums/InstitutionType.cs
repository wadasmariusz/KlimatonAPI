using System.ComponentModel.DataAnnotations;

namespace ThreatMap.Domain.Institutions.Enums;

public enum InstitutionType
{
    [Display(Name = "Brak danych")]
    NoData = 0,

    [Display(Name = "Przedszkole")]
    Kindergarten = 1,
    
    [Display(Name = "Szkoła")]
    School = 2,
    
    [Display(Name = "OSP")]
    OSP = 3,
    
    [Display(Name = "Filia Domu Kultury")]
    AgencyOfCultureHouse = 4
}
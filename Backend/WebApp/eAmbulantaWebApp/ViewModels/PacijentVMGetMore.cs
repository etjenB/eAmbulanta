using eAmbulantaWebApp.Models;

namespace eAmbulantaWebApp.ViewModels
{
    public class PacijentVMGetMore
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? JMBG { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string? Telefon { get; set; }
        public string? Mail { get; set; }
        public Lokacija? Lokacija { get; set; }
    }
}

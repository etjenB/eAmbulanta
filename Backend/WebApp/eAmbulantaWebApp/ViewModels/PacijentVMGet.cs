using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace eAmbulantaWebApp.ViewModels
{
    public class PacijentVMGet
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string? JMBG { get; set; }
    }
}

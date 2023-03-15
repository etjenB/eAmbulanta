using eAmbulantaWebApp.Data;
using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacijentController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private readonly AuthenticationContext db;

        public PacijentController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim, AuthenticationContext database)
        {
            userManager = um;
            signInManager = sim;
            db = database;
        }

        [HttpGet]
        [Authorize(Roles = "Doktor,MedicinskaSestraTehnicar,Administrator")]
        [Route("GetAll")]
        public async Task<Object> GetAll()
        {
            var p = await db.Pacijent.ToListAsync();
            return Ok(p);
        }

            [HttpPost]
        [Route("Registracija")]
        public async Task<Object> PostPacijent(PacijentVMReg kor)
        {
            var role = "Pacijent";
            var korisnik = new Pacijent()
            {
                UserName = kor.KorisnickoIme,
                Ime = kor.Ime,
                Prezime = kor.Prezime,
                Email = kor.Email,
                JMBG = kor.JMBG,
                datumRodjenja = DateTime.Parse(kor.DatumRodjenja),
                Lokacija = new Lokacija() { Adresa = kor.Lokacija.Adresa, Latitude = kor.Lokacija.Latitude, Longitude = kor.Lokacija.Longitude}
            };

            try
            {
                var result = await userManager.CreateAsync(korisnik, kor.Lozinka);
                await userManager.AddToRoleAsync(korisnik, role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("Get")]
        public async Task<Object> GetPacijent([FromQuery] string pacijentId)
        {
            var p = await db.Pacijent.FirstOrDefaultAsync(x => x.Id == pacijentId);
            var lok = await db.Lokacija.FirstOrDefaultAsync(x => x.Id == p.LokacijaID);
            PacijentVMGetMore pac = new PacijentVMGetMore { Ime = p.Ime, Prezime = p.Prezime, JMBG = p.JMBG, DatumRodjenja = p.datumRodjenja, Telefon = p.PhoneNumber, Mail = p.Email, Lokacija = lok};
            return Ok(pac);
        }
    }
}

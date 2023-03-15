using eAmbulantaWebApp.Class;
using eAmbulantaWebApp.Data;
using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PregledController : Controller
    {

        private readonly AuthenticationContext db;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public PregledController(AuthenticationContext db, UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            this.db = db;
            userManager = um;
            signInManager = sim;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllPregledi()
        {
            var Pregledi = await db.Pregled.ToListAsync();
            return Ok(Pregledi);
        }

        //Dio za pacijente------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Authorize(Roles = "Pacijent")]
        [Route("GetPrethodniTermini")]
        public async Task<IActionResult> GetPrethodniTermini()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            List<PregledVMGet> pregledi = new List<PregledVMGet>();
            foreach (var pr in db.Pregled)
            {
                if (pr.PacijentId == user.Id && pr.Obavljeno)
                {
                    pregledi.Add(new PregledVMGet { Id = pr.Id, Odobreno = pr.Odobreno, Datum = pr.DatumIVrijeme.ToString("yyyy-M-d"), Dijagnoza = pr.Dijagnoza, DoktorId = pr.DoktorId, Napomena = pr.Napomena, Obavljeno = pr.Obavljeno, Odgovor = pr.Odgovor, PacijentId = pr.PacijentId, Terapija = pr.Terapija, Vrijeme = pr.DatumIVrijeme.ToString("H:mm") });
                }
            }
            return Ok(pregledi);
        }

        [HttpGet]
        [Authorize(Roles = "Pacijent")]
        [Route("GetPreglediZaDatum")]
        public async Task<IActionResult> GetPreglediZaDatum(string datum, string id)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            List<string> zauzetaVremena = new List<string>();
            foreach (var pr in db.Pregled)
            {
                if ((pr.DatumIVrijeme.ToString("yyyy-MM-dd") == datum && (pr.DoktorId == id && pr.PacijentId == user.Id)) || (pr.DatumIVrijeme.ToString("yyyy-MM-dd") == datum && pr.DoktorId == id && pr.Odobreno))
                {
                    zauzetaVremena.Add(pr.DatumIVrijeme.ToString("H:mm"));
                }
            }
            return Ok(zauzetaVremena);
        }

        [HttpGet]
        [Authorize]
        [Route("GetTerminiKojiCekajuNaOdobrenje")]
        public async Task<IActionResult> GetTerminiKojiCekajuNaOdobrenje()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            List<PregledVMGet> pregledi = new List<PregledVMGet>();
            foreach (var pr in db.Pregled)
            {
                if (pr.PacijentId == user.Id && !pr.Odobreno && pr.DatumIVrijeme > DateTime.UtcNow)
                {
                    pregledi.Add(new PregledVMGet { Id = pr.Id, Odobreno = pr.Odobreno, Datum = pr.DatumIVrijeme.ToString("yyyy-M-d"), Dijagnoza = pr.Dijagnoza, DoktorId = pr.DoktorId, Napomena = pr.Napomena, Obavljeno = pr.Obavljeno, Odgovor = pr.Odgovor, PacijentId = pr.PacijentId, Terapija = pr.Terapija, Vrijeme = pr.DatumIVrijeme.ToString("H:mm")});
                }
            }
            return Ok(pregledi);
        }

        [HttpGet]
        [Authorize]
        [Route("GetNadolazeciTermini")]
        public async Task<IActionResult> GetNadolazeciTermini()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            List<PregledVMGet> pregledi = new List<PregledVMGet>();
            foreach (var pr in db.Pregled)
            {
                if (pr.PacijentId == user.Id && pr.Odobreno && pr.DatumIVrijeme > DateTime.UtcNow)
                {
                    pregledi.Add(new PregledVMGet { Id = pr.Id, Odobreno = pr.Odobreno, Datum = pr.DatumIVrijeme.ToString("yyyy-M-d"), Dijagnoza = pr.Dijagnoza, DoktorId = pr.DoktorId, Napomena = pr.Napomena, Obavljeno = pr.Obavljeno, Odgovor = pr.Odgovor, PacijentId = pr.PacijentId, Terapija = pr.Terapija, Vrijeme = pr.DatumIVrijeme.ToString("H:mm") });
                }
            }
            return Ok(pregledi);
        }

        [HttpGet]
        [Authorize]
        [Route("GetTerminUskoro")]
        public async Task<IActionResult> GetTerminUskoro()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            Pregled pregled = new Pregled { DatumIVrijeme = new DateTime(9999, 12, 31, 23, 59, 59)};
            foreach (var pr in db.Pregled)
            {
                if (pr.PacijentId == user.Id && pr.Odobreno && pr.DatumIVrijeme > DateTime.UtcNow && pr.Obavljeno!=true)
                {
                    if (pregled.DatumIVrijeme >= pr.DatumIVrijeme)
                    {
                        pregled = pr;
                    }
                }
            }
            DateTime dod = pregled.DatumIVrijeme;
            if (pregled.DatumIVrijeme == new DateTime(9999, 12, 31, 23, 59, 59) || dod.AddDays(-1) >= DateTime.UtcNow )
            {
                return Ok();
            }
            PregledVMGet pregledVMGet = new PregledVMGet {Id = pregled.Id, Terapija = pregled.Terapija, Dijagnoza = pregled.Dijagnoza, Odgovor = pregled.Odgovor, Datum = pregled.DatumIVrijeme.ToString("yyyy-M-d"), DoktorId = pregled.DoktorId, Napomena = pregled.Napomena, Obavljeno = pregled.Obavljeno, Odobreno = pregled.Odobreno, PacijentId = pregled.PacijentId, Vrijeme = pregled.DatumIVrijeme.ToString("H:mm") };
            return Ok(pregledVMGet);
        }

        [HttpDelete]
        [Authorize(Roles = "Pacijent")]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeletePregled([FromRoute] int id)
        {
            var pr = await db.Pregled.FirstOrDefaultAsync(x => x.Id == id);
            if (pr != null)
            {
                db.Remove(pr);
                await db.SaveChangesAsync();
                return Ok(pr);
            }
            return NotFound("Ne postoji pregled sa tim id-om u bazi podataka.");
        }

        [HttpPost]
        [Authorize(Roles = "Pacijent")]
        [Route("Add")]
        public async Task<IActionResult> AddPregled([FromBody] PregledVMAdd pregled)
        {
            try
            {
                var pr = new Pregled()
                {
                    Doktor = db.Doktor.ToList().Find(dok => dok.Id == pregled.DoktorId),
                    Pacijent = db.Pacijent.ToList().Find(pac => pac.Id == pregled.PacijentId)
                };
                pr.Napomena = pregled.Napomena;
                pr.DatumIVrijeme = DateTime.ParseExact(pregled.Datum + ' ' + pregled.Vrijeme, "yyyy-MM-dd H:mm", System.Globalization.CultureInfo.InvariantCulture);
                //pr.Doktor = await db.Doktor.FirstOrDefaultAsync(x => x.Id == pr.Doktor.Id);
                db.Pacijent.ToList().Find(pac => pr.PacijentId == pac.Id)?.PacijentPregledi.Add(pr);
                db.Doktor.ToList().Find(dok => pr.DoktorId == dok.Id)?.DoktorPregledi.Add(pr);
                await db.Pregled.AddAsync(pr);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Pacijent,Doktor,MedicinskaSestraTehnicar")]
        [Route("GetPrethodniTerminiPacijent")]
        public async Task<IActionResult> GetPrethodniTerminiPacijent([FromQuery]string id)
        {
            string userId = id;
            var user = await userManager.FindByIdAsync(userId);
            List<PregledVMGet> pregledi = new List<PregledVMGet>();
            foreach (var pr in db.Pregled)
            {
                if (pr.PacijentId == user.Id && pr.Obavljeno)
                {
                    pregledi.Add(new PregledVMGet { Id = pr.Id, Odobreno = pr.Odobreno, Datum = pr.DatumIVrijeme.ToString("yyyy-M-d"), Dijagnoza = pr.Dijagnoza, DoktorId = pr.DoktorId, Napomena = pr.Napomena, Obavljeno = pr.Obavljeno, Odgovor = pr.Odgovor, PacijentId = pr.PacijentId, Terapija = pr.Terapija, Vrijeme = pr.DatumIVrijeme.ToString("H:mm") });
                }
            }
            return Ok(pregledi);
        }

        //Dio za doktore------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Authorize(Roles = "Doktor")]
        [Route("GetTerminiKojiCekajuNaOdobrenjeDoktor")]
        public async Task<IActionResult> GetTerminiKojiCekajuNaOdobrenjeDoktor()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            List<PregledVMGet> pregledi = new List<PregledVMGet>();
            foreach (var pr in db.Pregled)
            {
                if (pr.DoktorId == user.Id && !pr.Odobreno && pr.DatumIVrijeme > DateTime.UtcNow)
                {
                    var p = await db.Pacijent.FirstOrDefaultAsync(x => x.Id == pr.PacijentId);
                    PacijentVMGet pac = new PacijentVMGet { Ime = p.Ime, Prezime = p.Prezime, JMBG = p.JMBG };
                    pregledi.Add(new PregledVMGet { Id = pr.Id, Odobreno = pr.Odobreno, Datum = pr.DatumIVrijeme.ToString("yyyy-M-d"), Dijagnoza = pr.Dijagnoza, DoktorId = pr.DoktorId, Napomena = pr.Napomena, Obavljeno = pr.Obavljeno, Odgovor = pr.Odgovor,
                        PacijentId = pr.PacijentId,
                        Pacijent = pac,
                        Terapija = pr.Terapija, Vrijeme = pr.DatumIVrijeme.ToString("H:mm") });
                }
            }
            return Ok(pregledi);
        }

        [HttpGet]
        [Authorize(Roles = "Doktor")]
        [Route("GetTerminiDanas")]
        public async Task<IActionResult> GetTerminiDanas()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            List<PregledVMGet> pregledi = new List<PregledVMGet>();
            List<Pregled> SortedList = db.Pregled.OrderBy(o => o.DatumIVrijeme).ToList();
            foreach (var pr in SortedList)
            {
                if (pr.DoktorId == user.Id && pr.Odobreno && pr.DatumIVrijeme.Date == DateTime.UtcNow.Date && pr.Obavljeno!=true)
                {
                    var p = await db.Pacijent.FirstOrDefaultAsync(x => x.Id == pr.PacijentId);
                    PacijentVMGet pac = new PacijentVMGet { Ime = p.Ime, Prezime = p.Prezime, JMBG = p.JMBG };
                    pregledi.Add(new PregledVMGet { Id = pr.Id, Odobreno = pr.Odobreno, Datum = pr.DatumIVrijeme.ToString("yyyy-M-d"), Dijagnoza = pr.Dijagnoza, DoktorId = pr.DoktorId, Napomena = pr.Napomena, Obavljeno = pr.Obavljeno, Odgovor = pr.Odgovor, PacijentId = pr.PacijentId, Pacijent = pac, Terapija = pr.Terapija, Vrijeme = pr.DatumIVrijeme.ToString("H:mm") });
                }
            }
            return Ok(pregledi);
        }

        [HttpGet]
        [Authorize(Roles = "Doktor")]
        [Route("GetPrethodniTerminiDoktor")]
        public async Task<IActionResult> GetPrethodniTerminiDoktor()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            List<PregledVMGet> pregledi = new List<PregledVMGet>();
            foreach (var pr in db.Pregled)
            {
                if (pr.DoktorId == user.Id && pr.Obavljeno)
                {
                    pregledi.Add(new PregledVMGet { Id = pr.Id, Odobreno = pr.Odobreno, Datum = pr.DatumIVrijeme.ToString("yyyy-M-d"), Dijagnoza = pr.Dijagnoza, DoktorId = pr.DoktorId, Napomena = pr.Napomena, Obavljeno = pr.Obavljeno, Odgovor = pr.Odgovor, PacijentId = pr.PacijentId, Terapija = pr.Terapija, Vrijeme = pr.DatumIVrijeme.ToString("H:mm") });
                }
            }
            return Ok(pregledi);
        }

        [HttpPut]
        [Authorize(Roles = "Doktor")]
        [Route("Odobri")]
        public async Task<IActionResult> OdobriTermin([FromBody] PregledVMOdobri pregled)
        {
            var pr = await db.Pregled.FirstOrDefaultAsync(x => x.Id == pregled.Id);
            if (pr != null)
            {
                var pa = await db.Pacijent.FirstOrDefaultAsync(x => x.Id == pr.PacijentId);
                pr.Odobreno = pregled.Odobreno;
                pr.Odgovor = pregled.Odgovor;
                await db.SaveChangesAsync();
                if (pa?.Email!=null)
                {
                    SendMail.SendEmail("Odobren termin", "Postovanje, vas zahtjev za termin kojeg ste zakazali za " + pr.DatumIVrijeme.ToShortDateString() + " je odobren.", pa.Ime + " " + pa.Prezime, pa.Email);
                }
                return Ok();
            }
            return NotFound("Ne postoji pregled sa tim id-om u bazi podataka.");
        }

        [HttpDelete]
        [Authorize(Roles = "Doktor")]
        [Route("Odbij")]
        public async Task<IActionResult> DeleteNovost([FromQuery] int pregledId)
        {
            var n = await db.Pregled.FirstOrDefaultAsync(x => x.Id == pregledId);
            if (n != null)
            {
                db.Remove(n);
                await db.SaveChangesAsync();
                return Ok(n);
            }
            return NotFound("Ne postoji pregled sa tim id-om u bazi podataka.");
        }

        [HttpPut]
        [Authorize(Roles = "Doktor")]
        [Route("Zavrsi")]
        public async Task<IActionResult> ZavrsiPregled([FromBody] PregledVMUpdate pregled)
        {
            var p = await db.Pregled.FirstOrDefaultAsync(x => x.Id == pregled.Id);
            if (p==null)
            {
                return NotFound("Ne postoji pregled sa tim ID-om u bazi podataka.");
            }
            p.Dijagnoza = pregled.Dijagnoza;
            p.Terapija = pregled.Terapija;
            p.Obavljeno = true;
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}

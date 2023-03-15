using eAmbulantaWebApp.Data;
using eAmbulantaWebApp.Models;
using eAmbulantaWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eAmbulantaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinskiTretmanController : Controller
    {
        private readonly AuthenticationContext db;

        public MedicinskiTretmanController(AuthenticationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> getAllTretmani()
        {
            var medicinskiTretmani = await db.MedicinskiTretman.ToListAsync();
            return Ok(medicinskiTretmani);
        }

        [HttpGet]
        [Authorize(Roles = "Doktor,MedicinskaSestraTehnicar")]
        [Route("GetNadolazeciTretmaniZaPacijenta")]
        public async Task<IActionResult> GetNadolazeciTretmaniZaPacijenta([FromQuery] string pacijentId)
        {
            var mt = await db.MedicinskiTretman.Where(x=>x.PacijentId==pacijentId && x.Obavljen == false).ToListAsync();
            return Ok(mt);
        }

        [HttpPost]
        [Authorize(Roles = "Doktor,MedicinskaSestraTehnicar")]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] MedicinskiTretmanVMAdd medicinskiTretman)
        {
            var mt = new MedicinskiTretman { PacijentId = medicinskiTretman.PacijentId, 
                Opis = medicinskiTretman.Opis, 
                Napomena = medicinskiTretman.Napomena, 
                DatumIVrijemePropisa = DateTime.Now
            };
            await db.MedicinskiTretman.AddAsync(mt);
            await db.SaveChangesAsync();
            return Ok(mt);
        }

        [HttpDelete]
        [Authorize(Roles = "Doktor,MedicinskaSestraTehnicar")]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int tretmanId)
        {
            var mt = await db.MedicinskiTretman.FirstOrDefaultAsync(x => x.Id == tretmanId);
            if (mt == null)
            {
                return NotFound("Ne postoji tretman sa tim ID-om u bazi podataka.");
            }
            db.MedicinskiTretman.Remove(mt);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Doktor,MedicinskaSestraTehnicar")]
        [Route("Obavi")]
        public async Task<IActionResult> Obavi([FromBody] MedicinskiTretmanVMUpdate medicinskiTretman)
        {
            var mt = await db.MedicinskiTretman.FirstOrDefaultAsync(x => x.Id == medicinskiTretman.TretmanId);
            if (mt==null)
            {
                return NotFound("Ne postoji tretman sa tim ID-om u bazi podataka.");
            }
            mt.Obavljen = medicinskiTretman.Obavljeno;
            mt.DatumIVrijemeObavljanja = DateTime.Now;
            await db.SaveChangesAsync();
            return Ok(mt);
        }

    }
}

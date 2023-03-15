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
    public class BolestController : Controller
    {
        private readonly AuthenticationContext db;

        public BolestController(AuthenticationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Authorize(Roles = "Pacijent,Doktor,MedicinskaSestraTehnicar")]
        [Route("GetBolestiZaPacijenta")]
        public async Task<IActionResult> GetBolestiZaPacijenta([FromQuery] string pacijentId)
        {
            var b = await db.Bolest.Where(p => p.PacijentId == pacijentId).ToListAsync();
            return Ok(b);
        }

        [HttpPost]
        [Authorize(Roles = "Doktor,MedicinskaSestraTehnicar")]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] BolestVMAdd bolest)
        {
            //var p = await db.Pacijent.FirstOrDefaultAsync(x => x.Id == bolest.PacijentId);
            //if (p==null)
            //{
            //    return NotFound("Ne postoji pacijent sa tim ID-om u bazi podataka");
            //}
            var b = new Bolest { PacijentId = bolest.PacijentId, Naziv = bolest.Naziv, Opis = bolest.Opis, ICDKod = bolest.ICDKod };
            await db.Bolest.AddAsync(b);
            await db.SaveChangesAsync();
            return Ok(b);
        }

        [HttpDelete]
        [Authorize(Roles = "Doktor,MedicinskaSestraTehnicar")]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int bolestId)
        {
            var b = await db.Bolest.FirstOrDefaultAsync(x => x.Id == bolestId);
            if (b==null)
            {
                return NotFound("Ne postoji bolest sa tim ID-om u bazi podataka.");
            }
            db.Bolest.Remove(b);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}

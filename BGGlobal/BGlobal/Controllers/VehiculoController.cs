using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BGlobal.Data;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BGlobal.Models
{
    public class VehiculoController : Controller
    {
        private readonly BGlobalContext _context;

        public VehiculoController(BGlobalContext context)
        {
            _context = context;
        }

        // GET: Vehículo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehículo.ToListAsync());
        }

        // GET: Vehículo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehículo = await _context.Vehículo
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehículo == null)
            {
                return NotFound();
            }

            return View(vehículo);
        }

        // GET: Vehículo/Create
        public async Task<IActionResult> CreateAsync()
        {


            var Titulares = new List<SelectListItem>();

            var Marca = new List<SelectListItem>();
            Marca.Add(new SelectListItem() { Text = "Fiat", Value = "Fiat" });
            Marca.Add(new SelectListItem() { Text = "Peugeot", Value = "Peugeot" });
            Marca.Add(new SelectListItem() { Text = "Audi", Value = "Audi" });
            ViewBag.Marca = Marca;            
            string baseURL = "https://reqres.in/api/users";
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(baseURL);
            HttpContent content = res.Content;
            string data = await content.ReadAsStringAsync();
            var jsonValue = JsonConvert.DeserializeObject(data);

            var models = JsonConvert.DeserializeObject<Titular>(data);
            foreach (Datum x  in models.data)
            {
                Titulares.Add(new SelectListItem() { Text = x.first_name + " " + x.last_name,
                    Value = x.first_name + " " + x.last_name});                
            }
            ViewBag.Titulares = Titulares;

           

            return View();
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculo,Patente,Marca,Modelo,Puertas,Titular")] Vehiculo vehículo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehículo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehículo);
        }

        // GET: Vehículo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehículo = await _context.Vehículo.FindAsync(id);
            if (vehículo == null)
            {
                return NotFound();
            }
            return View(vehículo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculo,Patente,Marca,Modelo,Puertas,Titular")] Vehiculo vehículo)
        {
            if (id != vehículo.IdVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehículo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehículoExists(vehículo.IdVehiculo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehículo);
        }

        // GET: Vehículo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehículo = await _context.Vehículo
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehículo == null)
            {
                return NotFound();
            }

            return View(vehículo);
        }

        // POST: Vehículo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehículo = await _context.Vehículo.FindAsync(id);
            _context.Vehículo.Remove(vehículo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehículoExists(int id)
        {
            return _context.Vehículo.Any(e => e.IdVehiculo == id);
        }
    }
}

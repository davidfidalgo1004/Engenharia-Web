using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using normal_23012024.Data;
using normal_23012024.Models;

namespace normal_23012024.Controllers
{
    [ResponseCache(Location =ResponseCacheLocation.Client, Duration = 100)]
    public class RegistosController : Controller
    {
        private readonly normal_23012024Context _context;

        public RegistosController(normal_23012024Context context)
        {
            _context = context;
        }

        // GET: Registos
        public async Task<IActionResult> Lista()
        {
            HttpContext.Session.SetString("Estado", "Editar");
            return View(await _context.RegistoUtilizador.ToListAsync());
        }

        public IActionResult Invalida(int id)
        {
            var registo = _context.RegistoUtilizador.FirstOrDefault(x=> x.RegistoId==id);
            registo.Valido = false;
            _context.Update(registo);
            _context.SaveChanges();
            return PartialView("Listagem", _context.RegistoUtilizador);
        }

        public IActionResult Valida(int id)
        {
            var registo = _context.RegistoUtilizador.FirstOrDefault(x => x.RegistoId == id);
            registo.Valido = true;
            _context.Update(registo);
            _context.SaveChanges();
            return PartialView("Listagem", _context.RegistoUtilizador);
        }

        // GET: Registos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoUtilizador = await _context.RegistoUtilizador
                .FirstOrDefaultAsync(m => m.RegistoId == id);
            if (registoUtilizador == null)
            {
                return NotFound();
            }

            return View(registoUtilizador);
        }

        // GET: Registos/Create
        public IActionResult Adiciona()
        {
            return View();
        }

        // POST: Registos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adiciona([Bind("RegistoId,Nome,Regime,Valido")] RegistoUtilizador registoUtilizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registoUtilizador);
                await _context.SaveChangesAsync();
                TempData["MsgOk"] = "Utilizador registado com sucesso!";
                return RedirectToAction(nameof(Lista));
            }
            return View(registoUtilizador);
        }

        // GET: Registos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoUtilizador = await _context.RegistoUtilizador.FindAsync(id);
            if (registoUtilizador == null)
            {
                return NotFound();
            }
            return View(registoUtilizador);
        }

        // POST: Registos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistoId,Nome,Regime,Valido")] RegistoUtilizador registoUtilizador)
        {
            if (id != registoUtilizador.RegistoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registoUtilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistoUtilizadorExists(registoUtilizador.RegistoId))
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
            return View(registoUtilizador);
        }

        // GET: Registos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registoUtilizador = await _context.RegistoUtilizador
                .FirstOrDefaultAsync(m => m.RegistoId == id);
            if (registoUtilizador == null)
            {
                return NotFound();
            }

            return View(registoUtilizador);
        }

        // POST: Registos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registoUtilizador = await _context.RegistoUtilizador.FindAsync(id);
            if (registoUtilizador != null)
            {
                _context.RegistoUtilizador.Remove(registoUtilizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistoUtilizadorExists(int id)
        {
            return _context.RegistoUtilizador.Any(e => e.RegistoId == id);
        }
    }
}

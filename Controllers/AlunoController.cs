using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudAlumni.Data;
using CrudAlumni.Models;

namespace CrudAlumni.Controllers
{
    public class AlunoController : Controller
    {
        private readonly CrudAlumniContext _context;

        public AlunoController(CrudAlumniContext context)
        {
            _context = context;
        }

        // GET: Aluno
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aluno.ToListAsync());
        }

        // GET: Aluno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Aluno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,Nome,DataNascimento,TipoEndereco,Rua,CEP,Numero,Complemento,Serie,Segmento,NomePai,NomeMae")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                // Validar a idade do aluno com base na série
                if (!aluno.ValidarIdade())
                {
                    ModelState.AddModelError(string.Empty, "Idade não corresponde à série selecionada.");
                    return View(aluno);
                }

                // Definir o segmento automaticamente com base na série
                aluno.DefinirSegmento();

                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Aluno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricula,Nome,DataNascimento,TipoEndereco,Rua,CEP,Numero,Complemento,Serie,Segmento,NomePai,NomeMae")] Aluno aluno)
        {
            if (id != aluno.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Validar a idade do aluno com base na série
                    if (!aluno.ValidarIdade())
                    {
                        ModelState.AddModelError(string.Empty, "Idade não corresponde à série selecionada.");
                        return View(aluno);
                    }

                    // Definir o segmento automaticamente com base na série
                    aluno.DefinirSegmento();

                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Matricula))
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
            return View(aluno);
        }

        // GET: Aluno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno != null)
            {
                _context.Aluno.Remove(aluno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.Matricula == id);
        }
    }
}

#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_EFCF.Data;
using MVC_EFCF.Models;

namespace MVC_EFCF
{
    public class TaxDocumentsController : Controller
    {
        private readonly MVC_EFCFContext _context;

        public TaxDocumentsController(MVC_EFCFContext context)
        {
            _context = context;
        }

        // GET: TaxDocuments
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaxDocument.ToListAsync());
        }

        // GET: TaxDocuments/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxDocument = await _context.TaxDocument
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxDocument == null)
            {
                return NotFound();
            }

            return View(taxDocument);
        }

        // GET: TaxDocuments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxDocuments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NIT,Name,DocumentType,DocumentNumber,DocumentComplement,Currency,TotalAmount")] TaxDocument taxDocument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxDocument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxDocument);
        }

        // GET: TaxDocuments/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxDocument = await _context.TaxDocument.FindAsync(id);
            if (taxDocument == null)
            {
                return NotFound();
            }
            return View(taxDocument);
        }

        // POST: TaxDocuments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,NIT,Name,DocumentType,DocumentNumber,DocumentComplement,Currency,TotalAmount")] TaxDocument taxDocument)
        {
            if (id != taxDocument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxDocument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxDocumentExists(taxDocument.Id))
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
            return View(taxDocument);
        }

        // GET: TaxDocuments/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxDocument = await _context.TaxDocument
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxDocument == null)
            {
                return NotFound();
            }

            return View(taxDocument);
        }

        // POST: TaxDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var taxDocument = await _context.TaxDocument.FindAsync(id);
            _context.TaxDocument.Remove(taxDocument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxDocumentExists(long id)
        {
            return _context.TaxDocument.Any(e => e.Id == id);
        }
    }
}

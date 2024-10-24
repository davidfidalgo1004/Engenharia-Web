using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula5.Data;
using Aula5.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;

namespace Aula5.Controllers
{
    public class BooksController : Controller
    {
        private readonly Aula5Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BooksController(Aula5Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Book.ToListAsync());
        }

        public IActionResult Download(string? id)
        {
            string pathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Documents", id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(pathFile);
            string? mimeType;
            if (new FileExtensionContentTypeProvider().TryGetContentType(id,out mimeType) == false)
            {
                mimeType = "application/force-download"; 
            }
            return File(fileBytes, mimeType);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CoverPhoto,Document")] BookViewModel book)
        {
            //Validate the extension of the file submitted
            var PhotoExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            var DocumentExtensions = new[] { ".pdf", ".doc", ".docx", ".epub" };

            var extension = Path.GetExtension(book.CoverPhoto.FileName).ToLower();

            if(!PhotoExtensions.Contains(extension))
            {
                ModelState.AddModelError("CoverPhoto", "Please submit a valid Image");
            }

            extension = Path.GetExtension(book.Document.FileName).ToLower();

            if (!DocumentExtensions.Contains(extension))
            {
                ModelState.AddModelError("Document", "Please submit a valid Document");
            }

            if (ModelState.IsValid)
            {
                var NewBook = new Book();
                
                NewBook.Title = book.Title;
                NewBook.CoverPhoto = Path.GetFileName(book.CoverPhoto.FileName);
                
                //Save the files in the file sistem of the server int the corresponding folders

                string coverFileName = Path.GetFileName(book.CoverPhoto.FileName);
                string coverFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "Cover", coverFileName);
                using (var stream = new FileStream(coverFullPath, FileMode.Create))
                {
                    await book.CoverPhoto.CopyToAsync(stream);

                }
                string docFileName = Path.GetFileName(book.Document.FileName);
                string docFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "Documents", docFileName);
                using (var stream = new FileStream(docFullPath, FileMode.Create))
                {
                    await book.Document.CopyToAsync(stream);
                }
                string documentFileName = Path.GetFileName(book.Document.FileName);
                _context.Add(NewBook);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CoverPhoto,Document")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}

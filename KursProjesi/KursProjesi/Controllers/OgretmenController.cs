using KursProjesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursProjesi.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly DataContext _context;

        public OgretmenController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ogretmenler = await _context.Ogretmenler.ToListAsync();

            return View(ogretmenler);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen ogretmen)
        {
            _context.Ogretmenler.Add(ogretmen);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var ogr = await _context.Ogretmenler.FirstOrDefaultAsync(i => i.OgretmenID == Id);

            if (ogr == null)
            {
                return NotFound();
            }

            return View(ogr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Ogretmen ogretmen)
        {
            if (Id != ogretmen.OgretmenID)
            {
                return NotFound();
            }

            try
            {
                
                _context.Update(ogretmen);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                if (!_context.Ogretmenler.Any(i => i.OgretmenID == ogretmen.OgretmenID))
                {
                    return NotFound(ex.Message);
                }

            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler.FindAsync(Id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            _context.Ogretmenler.Remove(ogretmen);
            _context.SaveChanges();



            return RedirectToAction("Index");

        }

    }
}

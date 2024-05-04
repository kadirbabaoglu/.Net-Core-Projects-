using KursProjesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursProjesi.Controllers
{
    public class OgrenciController: Controller
    {
        private readonly DataContext _context;

        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
            return View(ogrenciler);
        }
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci ogrenci)
        {
            _context.Ogrenciler.Add(ogrenci);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int Id) 
        {
            if(Id == null)
            {
                return NotFound();
            }

            var ogr = await _context.Ogrenciler.Include(i => i.KursKayitlari).ThenInclude(i => i.Kurs).FirstOrDefaultAsync(i => i.OgrenciId == Id);

            if(ogr == null)
            {
                return NotFound();
            }
            
            return View(ogr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id ,Ogrenci ogrenci)
        {
            if(Id != ogrenci.OgrenciId)
            {
                return NotFound();
            }

            try
            {
               _context.Update(ogrenci);
                await _context.SaveChangesAsync();  
                
            }catch(Exception ex)
            {
                if(!_context.Ogrenciler.Any(i => i.OgrenciId == ogrenci.OgrenciId))
                {
                    return NotFound(ex.Message);
                }

            }

            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> Delete(int Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            var ogr = await _context.Ogrenciler.FindAsync(Id);
            if (ogr == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogr);
            _context.SaveChanges();


            
            return RedirectToAction("Index");

        }

    }
}

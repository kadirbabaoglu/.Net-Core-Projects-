using KursProjesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursProjesi.Controllers
{
    public class KursController : Controller
    {
        public readonly DataContext _context;

        public KursController(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<ActionResult> Index()
        {
            return View( await _context.Kurslar.ToListAsync());
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Kurs model)
        {

            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int Id)
        {
            
            if(Id == null) 
            {
                return NotFound();
            }
            
            var Kurslar = await _context.Kurslar.Include(i => i.KursKayitlari).ThenInclude(i => i.Ogrenci).FirstOrDefaultAsync(i => i.KursId == Id);

            if(Kurslar == null)
            {
                return NotFound();
            }

            return View(Kurslar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id ,Kurs model)
        {

            if (Id != model.KursId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                if (!_context.Kurslar.Any(i => i.KursId == model.KursId))
                {
                    return NotFound(ex.Message);
                }

            }

            return RedirectToAction("Index");
        }


        
        public async Task<ActionResult> Delete(int Id)
        {
            if(Id == null)
            {
                return NotFound() ;
            }

            var kurslar = await _context.Kurslar.FindAsync(Id);
            if(kurslar == null)
            {
                return NotFound();
            }

            _context.Kurslar.Remove(kurslar);
            _context.SaveChanges(); 

            return RedirectToAction("Index");




        }

       
    }
}

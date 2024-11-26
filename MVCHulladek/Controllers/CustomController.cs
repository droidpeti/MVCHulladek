using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCHulladek.Data;
using MVCHulladek.Models;
using MVCHulladek.Models.ViewModels;

namespace MVCHulladek.Controllers
{
    public class CustomController : Controller
    {
        private readonly MVCHulladekContext _context;

        public CustomController(MVCHulladekContext context)
        {
            _context = context;
        }

        public IActionResult LastKomDate()
        {
            var LastKom = (from Naptar n in _context.Naptar.Include(p => p.Szolgaltatas) where n.Szolgaltatas.Tipus == "kom" select n).OrderByDescending(c => c.Datum).FirstOrDefault();
            return View(LastKom);
        }

        public IActionResult JanuarGreen() 
        {
            List<Naptar> JanuarGreenList = (from Naptar n in _context.Naptar.Include(p => p.Szolgaltatas) where n.Datum.Month == 1 && n.Szolgaltatas.Tipus == "zold" select n).ToList();
            return View(JanuarGreenList);
        }

        public IActionResult GreenCount()
        {
            var greenCountsByYear = _context.Lakig
                .Include(l => l.Szolgaltatas)
                .Where(l => l.Szolgaltatas.Tipus == "zold")
                .GroupBy(l => l.Igeny.Year)
                .Select(group => new GreenCountViewModel
                {
                    Year = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return View(greenCountsByYear);
        }

        public IActionResult MostCountMonth()
        {
            MostCountMonthViewModel maxCountMonth = _context.Lakig
                .GroupBy(l => l.Igeny.Month)
                .Select(group => new MostCountMonthViewModel
                {
                    Month = group.Key,
                    Count = group.Sum(l => l.Mennyiseg)
                })
                .OrderByDescending(l => l.Count).FirstOrDefault();
            return View(maxCountMonth);
        }

        public IActionResult PaMuaDay()
        {
            List<DateTime> days = _context.Naptar
                .Include(n => n.Szolgaltatas)
                .GroupBy(n => n.Datum)
                .Where(group => group.Any(n => n.Szolgaltatas.Tipus == "pa") &&
                                group.Any(n => n.Szolgaltatas.Tipus == "mua"))
                .Select(group => group.Key)
                .ToList();

            return View(days);
        }

        public IActionResult MonthlyStat() 
        { 
            List<MonthlyStatViewModel> Stats = _context.Naptar
                .Include(n => n.Szolgaltatas)
                .GroupBy(n => new { Month = n.Datum.Month, Tipus = n.Szolgaltatas.Jelentes })
                .Select(group => new MonthlyStatViewModel
                {
                    Month = group.Key.Month,
                    Type = group.Key.Tipus,
                    Count = group.Count()
                }).ToList();

            return View(Stats);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

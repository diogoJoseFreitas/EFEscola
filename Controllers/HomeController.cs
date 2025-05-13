using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EscolaScaffolding.Models;

namespace EscolaScaffolding.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MeuAppDbContext _db;

    public HomeController(ILogger<HomeController> logger, MeuAppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Test( MeuAppDbContext db ){
        var teste = db.Alunos.ToList();
        return View(teste);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

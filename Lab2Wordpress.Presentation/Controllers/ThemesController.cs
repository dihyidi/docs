using Lab2Wordpress.Business.Services.Interfaces;
using Lab2Wordpress.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lab2Wordpress.Presentation.Controllers;

public class ThemesController : Controller
{
    private readonly IThemeService themesService;

    public ThemesController(IThemeService themesService)
    {
        this.themesService = themesService;
    }

    public async Task<IActionResult> GetAll()
    {
        return View(await themesService.GetAllAsync());
    }

    public async Task<IActionResult> GetById(int id)
    {
        return View(await themesService.GetByIdAsync(id));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Theme theme)
    {
        return View(await themesService.CreateAsync(theme));
    }

    public async Task<IActionResult> Generate()
    {
        return View(await themesService.GenerateAndWriteToCsvAsync());
    }

    public async Task<IActionResult> GetAllAndWriteToCsv()
    {
        return View(await themesService.GetAllAndWriteToCsvAsync());
    }

    public async Task<IActionResult> ReadFromCsv()
    {
        return View(await themesService.ReadFromCsvAndSaveToDbAsync());
    }
}
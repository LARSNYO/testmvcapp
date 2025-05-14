using Microsoft.AspNetCore.Mvc;
using testmvcapp.Services.Interfaces;
using testmvcapp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace testmvcapp.Controllers;

public class BrandController : Controller
{
    private readonly IBrandService _brandService;
    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task<IActionResult> Index()
    {
        var brands = await _brandService.GetBrandsAsync();
        return View(brands);
    }
}
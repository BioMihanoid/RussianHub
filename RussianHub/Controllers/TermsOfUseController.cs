using Microsoft.AspNetCore.Mvc;

namespace RussianHub.Controllers;

public class TermsOfUseController : Controller
{
    private readonly ILogger<TermsOfUseController> _logger;

    public TermsOfUseController(ILogger<TermsOfUseController> logger)
    {
        _logger = logger;
    }

    public IActionResult Info()
    {
        return View();
    }

    public IActionResult Contacts()
    {
        return View();
    }

    public IActionResult Abuse()
    {
        return View();
    }

    public IActionResult Advertisement()
    {
        return View();
    }
}

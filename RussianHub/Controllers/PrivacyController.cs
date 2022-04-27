using Microsoft.AspNetCore.Mvc;

namespace RussianHub.Controllers;

public class PrivacyController : Controller
{
    private readonly ILogger<PrivacyController> _logger;

    public PrivacyController(ILogger<PrivacyController> logger)
    {
        _logger = logger;
    }
}
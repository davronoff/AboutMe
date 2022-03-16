using AboutMe.Domain;
using AboutMe.Service;
using AboutMe.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AboutMe.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public async  Task<IActionResult> Index()
        {
            var item = await _postService.GetAllPartifolio();
            return View(item);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel viewModel)
        {
            Post post = new Post()
            {
                Id = Guid.NewGuid(),
                partifolioName = viewModel.partifolioName,
                pratifolioDescription = viewModel.pratifolioDescription,
                imageFileName = viewModel.imageFileName
            };
            await _postService.AddPartifolio(post);
            return RedirectToAction("Index");
        }
    }
}

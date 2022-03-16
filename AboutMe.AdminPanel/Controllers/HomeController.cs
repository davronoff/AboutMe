using AboutMe.AdminPanel.Services;
using AboutMe.Domain;
using AboutMe.Service;
using AboutMe.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AboutMe.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeleteSaveimageInterface _deleteSaveimage;
        private readonly IPostService _postService;

        public HomeController(IPostService postService,
            IDeleteSaveimageInterface deleteSaveimage)
        {
            _deleteSaveimage = deleteSaveimage;
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
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _postService.GetByIdPartifolio(id);
            return View((EditViewModel)item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel viewModel)
        {
            if(viewModel.NewImage is not null)
            {
                _deleteSaveimage.DeleteImage(viewModel.imageFileName);
                viewModel.imageFileName = _deleteSaveimage.SaveImage(viewModel.NewImage);
            }
            var item = await _postService.UpdatePartifolio((Post)viewModel);
            return RedirectToAction("Index");
        }
    }
}

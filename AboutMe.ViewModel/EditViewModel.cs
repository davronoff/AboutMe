using AboutMe.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace AboutMe.ViewModel
{
    public class EditViewModel
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required, MaxLength(20)]
        public string partifolioName { get; set; }
        [Required, MaxLength(100)]
        public string pratifolioDescription { get; set; }
        public IFormFile NewImage { get; set; }
        public string imageFileName { get; set; }

        public static explicit operator EditViewModel(Post model)
        {
            return new EditViewModel()
            {
                Id = model.Id,
                partifolioName = model.partifolioName,
                pratifolioDescription = model.pratifolioDescription,
                imageFileName = model.imageFileName
            };
        }
        public static explicit operator Post(EditViewModel viewModel)
        {
            return new Post()
            {
                Id = viewModel.Id,
                partifolioName = viewModel.partifolioName,
                pratifolioDescription = viewModel.pratifolioDescription,
                imageFileName = viewModel.imageFileName
            };
        }
    }
}

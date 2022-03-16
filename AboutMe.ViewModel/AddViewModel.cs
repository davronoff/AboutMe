using System;
using System.ComponentModel.DataAnnotations;

namespace AboutMe.ViewModel
{
    public class AddViewModel
    {
        [Required, MaxLength(20)]
        public string partifolioName { get; set; }
        [Required, MaxLength(100)]
        public string pratifolioDescription { get; set; }
        public string imageFileName { get; set; }
    }
}

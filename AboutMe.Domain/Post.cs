using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AboutMe.Domain
{
    [Table("Partifolios")]
    public class Post
    {
        [Required,Key]
        public Guid Id { get; set; }
        [Required, MaxLength(20)]
        public string partifolioName { get; set; }
        [Required,MaxLength(100)]
        public string pratifolioDescription { get; set; }
        public string imageFileName { get; set; }
    }
}
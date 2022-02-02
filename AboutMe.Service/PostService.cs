using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AboutMe.Data;
using AboutMe.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AboutMe.Service
{
    public class PostService : IPostService
    {
        private readonly PartifolioDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostService(PartifolioDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public Task<Post> AddPartifolio(Post newPost)
        {
            _dbContext.Posts.Add(newPost);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(newPost);
        }

        public Task DeletePartifolio(Guid id)
        {
            Post post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(0);
        }

        public Task<List<Post>> GetAllPartifolio() =>_dbContext.Posts.ToListAsync();
        public Task<Post> GetByIdPartifolio(Guid id) => _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);

        public string SaveImage(IFormFile newFile)
        {
            string uniqueName = string.Empty;
            if (newFile.FileName != null)
            {
                string uplodFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + newFile.FileName;
                string filePath = Path.Combine(uplodFolder, uniqueName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                newFile.CopyTo(fileStream);
                fileStream.Close();
            }

            return uniqueName;
        }

        public Task<Post> UpdatePartifolio(Post post)
        {
        _dbContext.Posts.Update(post);
        _dbContext.SaveChangesAsync();
        return Task.FromResult(post);
        }
    }
}
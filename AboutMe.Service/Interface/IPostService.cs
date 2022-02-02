using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AboutMe.Domain;
using Microsoft.AspNetCore.Http;

namespace AboutMe.Service
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPartifolio();
        Task<Post> GetByIdPartifolio(Guid id);
        Task<Post> AddPartifolio(Post newPost);
        Task<Post> UpdatePartifolio(Post post);
        Task DeletePartifolio(Guid id);
        string SaveImage(IFormFile newFile);
    }
}
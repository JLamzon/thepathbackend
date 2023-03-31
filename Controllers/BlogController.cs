using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thepathbackend.Models;
using thepathbackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace thepathbackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _data;
        public BlogController(BlogService dataFromService)
        {
            dataFromService = dataFromService;
        }

        [HttpPost]
        [Route("AddBlogItem")]
        public bool AddBlogItem(BlogItemModel newBlogItem)
        {
            return _data.AddBlogItem(newBlogItem);
        }

        [HttpGet]
        [Route("GetBlogItems")]

        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _data.GetAllBlogItems();
        }

        [HttpGet]
        [Route("GetItemsByUserId/{UserId}")]

        public IEnumerable<BlogItemModel> GetItemsByUserid(int userId)
        {
            return _data.GetItemsByUserid(userId);
        }

        // [HttpGet]
        // [Route("GetItemsByCategory/{category}")]
        // public IEnumerable<BlogItemModel> GetItemsByCategory(string category){
        //     return _data.GetItemsByCategory(category);
        // }

        [HttpGet]
        [Route("GetItemsByDate/{date}")]
        public IEnumerable<BlogItemModel> GetItemByDate(string date)
        {
            return _data.GetItemsByDate(date);
        }

        [HttpGet]
        [Route("GetPublishedItems")]

        public IEnumerable<BlogItemModel> GetPublishedItems()
        {
            return _data.GetPublishedItems();
        }

        // [HttpGet]
        // [Route("GetItemsByTags/{Tag}")]

        // public List<BlogItemModel> GetItemsByTag(string Tag)
        // {
        //     return _data.GetItemsByTag(Tag);
        // }

        [HttpGet]
        [Route("GetBlogItemById/{id}")]
        public BlogItemModel GetBlogItemById(int id)
        {
            return _data.GetBlogItemById(id);
        }

        [HttpGet]
        [Route("UpdateBlogItem")]
        public bool UpdateBlogItem(BlogItemModel BlogUpdate)
        {
            return _data.UpdateBlogItem(BlogUpdate);
        }


        [HttpPost]
        [Route("DeleteBlogItem")]

        public bool DeleteBlogItem(BlogItemModel BlogDelete)
        {
            return _data.DeleteBlogItem(BlogDelete);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thepathbackend.Models;
using thepathbackend.Services.Context;

namespace thepathbackend.Services
{
    public class BlogService
    {
        private readonly DataContext _context;
        public BlogService(DataContext context)
        {
            _context = context;
        }
        public bool AddBlogItem(BlogItemModel newBlogItem)
        {
            _context.Add(newBlogItem);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _context.BlogInfo;
        }

        public IEnumerable<BlogItemModel> GetItemsByUserid(int userId)
        {
            return _context.BlogInfo.Where(item => item.Userid == userId);
        }

        public IEnumerable<BlogItemModel> GetItemsByDate(string date)
        {
            return _context.BlogInfo.Where(item => item.Date == date);
        }
    

        public IEnumerable<BlogItemModel> GetPublishedItems()
        {
            return _context.BlogInfo.Where(item => item.isPublish);
        }


        public BlogItemModel GetBlogItemById(int id)
        {
            return _context.BlogInfo.SingleOrDefault(item => item.Id == id);
        }


        public bool UpdateBlogItem(BlogItemModel BlogUpdate)
        {
            _context.Update<BlogItemModel>(BlogUpdate);
            return _context.SaveChanges() != 0;
        }


        public bool DeleteBlogItem(BlogItemModel BlogDelete)
        {
            BlogDelete.isDeleted = true;
            _context.Update<BlogItemModel>(BlogDelete);
            return _context.SaveChanges() != 0;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thepathbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace thepathbackend.Services.Context
{
    public class DataContext : DbContext
    {
        //tables for models
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<BlogItemModel> BlogInfo { get; set; }
        public DbSet<SchoolsModel> SchoolInfo { get; set; }
        public DbSet<EventItemModel> EventInfo { get; set; }

        //constructor // to remove error on 'base' you need to add DbContext to the public class above
        public DataContext(DbContextOptions options): base(options)
        {}


        //this is used to build out the backendtable for us
        protected override void OnModelCreating(ModelBuilder builder){
            //this codes help build the table for us.  takes our user model properties to tables into our models
            base.OnModelCreating(builder);
        }
    }
}
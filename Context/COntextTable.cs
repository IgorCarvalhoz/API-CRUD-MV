using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Context
{
    public class ContextTable : DbContext
    {
        public ContextTable (DbContextOptions <ContextTable> options) : base (options){

        }
        public DbSet<Contact> Contacts{get; set;}
    }
}
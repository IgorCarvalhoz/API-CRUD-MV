using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Contact
    {
       public int ID { get; set; } 
       public string? Name { get; set; }
       public string? PhoneNumber { get; set; }
       public string CreatedAt{get; set;} = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}   
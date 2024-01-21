using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using MVC.Context;

namespace MVC.Controllers
{
    public class ContactController : Controller {
    
        private readonly ContextTable? _context;
    
        public ContactController(ContextTable context)
        {
            _context = context;
        }
        public IActionResult Index(){
            var contacts = _context?.Contacts.ToList();
            return View(contacts);

        }
        public IActionResult Create(){
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact contact){
            if (ModelState.IsValid){
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }
    }
}
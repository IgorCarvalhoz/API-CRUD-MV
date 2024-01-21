using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using MVC.Context;
using System.Security.Authentication;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace MVC.Controllers
{
    public class ContactController : Controller {
    
        private readonly ContextTable _context;
    
        public ContactController(ContextTable context)
        {
            _context = context;
        }
        public IActionResult Index(){
            var contacts = _context.Contacts.ToList();
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
        public IActionResult Edit(int ID){
            var contact = _context.Contacts.Find(ID);
            if (contact is null ){
                return NotFound();
            } 
           return View(contact);
        }
        [HttpPost]
      public IActionResult Edit(Contact contact){
       var contactDataBase = _context.Contacts.Find(contact.ID);
       contactDataBase.Name = contact.Name;
       contactDataBase.PhoneNumber = contact.PhoneNumber;
       _context.Contacts.Update(contactDataBase);
       _context.SaveChanges();
        return RedirectToAction(nameof(Index));
      }
    }
}
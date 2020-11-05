using ASP.NET_MVC_Lab_Task2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_Lab_Task2.Controllers
{
    public class PersonController : Controller
    {
        static List<Person> persons = new List<Person>()
        {
            new Person() {Id=1, Name="sharif", Email="sharif@gmail.com", Salary="100000"},
            new Person() {Id=2, Name="hossain", Email="hossain@gmail.com", Salary="200000"},
            new Person() {Id=3, Name="natasha", Email="natasha@gmail.com", Salary="300000"},
        };

        // GET: Person
        public ActionResult Index()
        {
            return View(persons);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var person = from item in persons
              //           where item.Id == id
                //         select item;
            ViewBag.id = id;
            Person p = persons.Where(x => x.Id == id).First();
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int id,Person p)
        {
            Person personToUpdate = persons.Where(x => x.Id == id).First();
            personToUpdate.Id = id;
            personToUpdate.Name = p.Name;
            personToUpdate.Email = p.Email;
            personToUpdate.Salary = p.Salary;
            return RedirectToAction("/Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Person p)
        {
            persons.Add(p);
            return RedirectToAction("/Index");
        }
    }
}
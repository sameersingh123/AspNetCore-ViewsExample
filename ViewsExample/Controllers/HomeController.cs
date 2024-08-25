using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Asp .Net Core Demo App";

            List<Person> people = new List<Person>()
                {
                  new Person(){Name="Sameer", DateOfBirth=Convert.ToDateTime("30-08-1999"), PersonGender=Gender.Male},
                  new Person(){Name="Sawan", DateOfBirth=Convert.ToDateTime("18-08-1998"), PersonGender=Gender.Male},
                  new Person(){Name="Ankit", DateOfBirth=Convert.ToDateTime("24-01-1999"), PersonGender=Gender.Male}
                };
            //ViewData["people"] = people;
            //ViewBag.people = people;

            return View("Index",people);        //Views/Home/Index.cshtml      here ViewName=Index

        }

        [Route("person-details/{name}")]
        public IActionResult Details(string name)
        {
            if (name == null)
            {
                return Content("Person Name can't be null");
            }
            List<Person> people = new List<Person>()
                {
                  new Person(){Name="Sameer", DateOfBirth=Convert.ToDateTime("30-08-1999"), PersonGender=Gender.Male},
                  new Person(){Name="Sawan", DateOfBirth=Convert.ToDateTime("18-08-1998"), PersonGender=Gender.Male},
                  new Person(){Name="Ankit", DateOfBirth=Convert.ToDateTime("24-01-1999"), PersonGender=Gender.Male}
                };

            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();

            return View(matchingPerson);     //Views/Home/Details.cshtml

        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person() { Name = "Sara", PersonGender = Gender.Female, DateOfBirth = Convert.ToDateTime("26-08-2000") };
            Product product = new Product() { ProductId = 1, ProductName = "Book" };
            PersonWithProductWrapper personWithProductWrapper = new PersonWithProductWrapper() {PersonDetails=person, ProductDetails=product};
            return View(personWithProductWrapper);
        }

        [Route("home/all-products")]
        public IActionResult All()
        {
            return View();
            //Views/Home/All.cshtml
            //Views/Shared/All.cshtml
        }
    }
}

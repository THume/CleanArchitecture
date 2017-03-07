using System;
using System.Linq;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Guestbook> _guestbookRepository;

        public HomeController(IRepository<Guestbook> guestbookRepository)
        {
            _guestbookRepository = guestbookRepository;
        }

        public IActionResult Index()
        {
            if(!_guestbookRepository.List().Any())
            {
                var newGuestbook = new Guestbook()
                {
                    Name = "My Guestbook"
                };

                newGuestbook.Entries.Add(new GuestbookEntry { DateTimeCreated = DateTime.UtcNow.AddHours(-2), EmailAddress = "test@test.com", Message = "Hello Pips!" });
                newGuestbook.Entries.Add(new GuestbookEntry { DateTimeCreated = DateTime.UtcNow.AddHours(-1), EmailAddress = "qa@test.com", Message = "Hello Pips!!" });
                newGuestbook.Entries.Add(new GuestbookEntry { EmailAddress = "test2@test.com", Message = "Hello Pips!!!" });

                _guestbookRepository.Add(newGuestbook);
            }

            var guestbook = _guestbookRepository.GetById(1);

            var viewmodel = new HomePageViewModel();
            viewmodel.GuestbookName = guestbook.Name;
            viewmodel.PreviousEntries.AddRange(guestbook.Entries);

            return View(viewmodel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

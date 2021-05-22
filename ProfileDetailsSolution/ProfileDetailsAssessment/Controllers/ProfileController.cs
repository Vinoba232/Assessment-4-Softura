using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileDetailsAssessment.Models;
using ProfileDetailsAssessment.Services;

namespace ProfileDetailsAssessment.Controllers
{
    public class ProfileController : Controller
    {
        private ILogger<ProfileController> _logger;
        private IRepo<Profile> _repo;

        public ProfileController(IRepo<Profile> repo, ILogger<ProfileController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            List<Profile> profiles = _repo.GetAll().ToList();
            return View(profiles);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Profile profile)
        {
            _repo.Add(profile);
            
            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            return View();
        }
        


    }
}

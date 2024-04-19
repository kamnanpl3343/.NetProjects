using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using testkamna.Database;
using testkamna.Models;
using testkamna.Services;
using Microsoft.EntityFrameworkCore;

namespace testkamna.Controllers
{
    public class LeadsController : Controller
    {

        private readonly LeadsService _leadsService;
        private readonly TestKamnaContext _leadContext;

        public LeadsController(LeadsService leadsService , TestKamnaContext leadContext)
        {

            _leadsService = leadsService;
            _leadContext = leadContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new LeadsViewModel();
       
            model = await _leadsService.GetAllData(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LeadsViewModel model)
        {
            model = await _leadsService.GetAllData(model);
            return View("Index", model);
        }

        public async Task<IActionResult> Search(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;
            var data = await _leadsService.GetSearchData(searchString);
           
            return View("Index", data);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int LeadId)
        {
            var model = new LeadsViewModel();
            if (LeadId > 0)
            {
                var data = await _leadsService.LeadDetail(new LeadsViewModel
                {
                    LeadId = LeadId
                });
                model = data;
            }

            return View( model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LeadsViewModel model)
        {
            if (ModelState.IsValid)
            {
               await _leadsService.AddLead(model);
            }
            else
            {
                return View("Add", model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult>Delete(int LeadId)
        {
            var model = new LeadsViewModel
            {
                LeadId = LeadId
            };

            var result = await _leadsService.Delete(model);
            return View(result);
           /* return RedirectToAction("Index",result);*/
        }

        [HttpGet]
        public async Task<IActionResult> ProfileDetail(int id)
        {
            var model = new LeadsViewModel();
            if (id > 0)
            {
                var detail = await _leadsService.LeadDetail(new LeadsViewModel()
                {
                    LeadId = id,
                });
                model = detail;
            }

            return View("ProfileDetail", model);
        }

        [HttpGet]
        public IActionResult AddFollowUps(int id=0)
        {
            return PartialView("AddFollowUps", new FollowUpsViewModel() { LeadId = id });
        }


        [HttpPost]
        public async Task<IActionResult> AddFollowUps (FollowUpsViewModel model)
        {
           /* model.CreatedBy = User.FindFirst("email")?.Value;*/
            var data = await _leadsService.AddFollowUps(model);
            var dataList = await _leadsService.GetAllFollowUps(data);
           
            return PartialView("_FollowUps", dataList);
        }

        [HttpGet]
        public IActionResult AddComments(int id=0)
        {
            return PartialView("AddComments",new CommentsViewModel() { LeadId = id });
        }

        [HttpPost]
        public async Task<IActionResult> AddComments (CommentsViewModel model)
        {
            var data =await _leadsService.AddComments(model);
            var dataList = await _leadsService.GetAllComments(data);

            return PartialView("_Comments", dataList);
        }
    }
    }


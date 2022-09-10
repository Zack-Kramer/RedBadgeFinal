using System;
using Microsoft.AspNetCore.Mvc;
using MVC.Models._CardModels;
using MVC.Models._LandModels;
using MVC.Services;

namespace MVC_IndividualAuthentication.Controllers
{
    public class LandController : Controller
        //The name of the controller has to match the name of the folder within the view folder
    {
        private readonly ILandRepository _cRepo;
        public LandController(ILandRepository cRepo)
        {
            _cRepo = cRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lands = await _cRepo.GetLands();
            return View(lands);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LandCreate landCreate)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (await _cRepo.AddMana(landCreate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(landCreate);
            }
        }
        [HttpGet]
        //The get will have 'View' which will give all the information to card and will convert to another form
        public async Task<IActionResult> Details(int? id)
        {
            var land = await _cRepo.GetLandDetails(id.Value);
            if (land is null)
            {
                return NotFound();
            }
            return View(land);
        }
        [HttpGet]
        //The get will have 'View' which will give all the information to card and will convert to another form
        public async Task<IActionResult> Edit(int? id)
        {
            var land = await _cRepo.GetLandDetails(id.Value);
            if (land is null)
            {
                return NotFound();
            }
            return View(land);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, LandUpdate landUpdate)
        {
            if (id != landUpdate.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _cRepo.UpdateLand(id, landUpdate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(landUpdate);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var card = await _cRepo.GetLandDetails(id.Value);
            if (card is null)
            {
                return NotFound();
            }
            return View(card);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _cRepo.DeleteLand(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return UnprocessableEntity();
        }

    }
}


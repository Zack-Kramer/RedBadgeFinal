using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Data.Data;
using MVC.Models._CreatureModels;
using MVC.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_IndividualAuthentication.Controllers
{
    public class CreatureController : Controller
    {
        private readonly ICreatureRepository _cRepo;
        public CreatureController(ICreatureRepository cRepo)
        {
            _cRepo = cRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var creatures = await _cRepo.GetCreatures();
            return View(creatures);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatureCreate creatureCreate)
        {
            if (ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            if (await _cRepo.AddCreature(creatureCreate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(creatureCreate);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var creature = await _cRepo.GetCreaturebyId(id.Value);
            {
                return NotFound();
            }
            return View(creature);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var creature = await _cRepo.GetCreaturebyId(id.Value);
            if (creature is null)
            {
                return NotFound();
            }
            return View(creature);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreatureUpdate creatureUpdate)
        {
            if (id != creatureUpdate.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _cRepo.UpdateCreature(id, creatureUpdate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(creatureUpdate);
            }
        }

        //Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var creature = await _cRepo.GetCreaturebyId(id.Value);
            if (creature is null)
            {
                return NotFound();
            }
            return View(creature);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _cRepo.DeleteCreature(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return UnprocessableEntity();
        }
    }
}


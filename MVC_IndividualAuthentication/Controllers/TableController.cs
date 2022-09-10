using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models._TableModels;
using MVC.Models._UserModels;
using MVC.Services;

namespace MVC_IndividualAuthentication.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableRepository _cRepo;
        private readonly ICreatureRepository _creatureRepo;
        public TableController(ITableRepository cRepo, ICreatureRepository creatureRepo)
        {
            _cRepo = cRepo;
            _creatureRepo = creatureRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var table = await _cRepo.GetTable();
            return View(table);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TableCreate tableCreate = new TableCreate();
            tableCreate.CreatureSelectionList = _creatureRepo.GetCreatures().Result.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(tableCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TableCreate tableCreate)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (await _cRepo.AddTable(tableCreate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tableCreate);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var table = await _cRepo.GetTablebyId(id.Value);
            {
                return NotFound();
            }
            return View(table);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var table = await _cRepo.GetTablebyId(id.Value);
            if (table is null)
            {
                return NotFound();
            }
            return View(table);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TableUpdate tableUpdate)
        {
            if (id != tableUpdate.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _cRepo.UpdateTable(id, tableUpdate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tableUpdate);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var table = await _cRepo.GetTablebyId(id.Value);
            if (table is null)
            {
                return NotFound();
            }
            return View(table);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _cRepo.DeleteTable(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return UnprocessableEntity();
        }

    }
}


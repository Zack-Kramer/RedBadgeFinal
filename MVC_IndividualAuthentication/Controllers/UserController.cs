using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models._CreatureModels;
using MVC.Models._UserModels;
using MVC.Services;

namespace MVC_IndividualAuthentication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _cRepo;
        public UserController(IUserRepository cRepo)
        {
            _cRepo = cRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _cRepo.GetUser();
            return View(user);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreate userCreate)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (await _cRepo.AddUser(userCreate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(userCreate);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var user = await _cRepo.GetUserbyId(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _cRepo.GetUserbyId(id.Value);
            if (user is null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserUpdate userUpdate)
        {
            if (id != userUpdate.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _cRepo.UpdateUser(id, userUpdate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(userUpdate);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _cRepo.GetUserbyId(id.Value);
            if (user is null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _cRepo.DeleteUser(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return UnprocessableEntity();
        }
    }
}


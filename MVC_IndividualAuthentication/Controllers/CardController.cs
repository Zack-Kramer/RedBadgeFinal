using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Data.Data;
using MVC.Models._CardModels;
using MVC.Services;
using MVC_IndividualAuthentication.Models;

namespace MVC_IndividualAuthentication.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardRepository _cRepo;
        public CardController(ICardRepository cRepo)
        {
            _cRepo = cRepo;
            //CardController CANNOT EXIST without ICardRepository 'filling it in' hence why it is called dependency injection
            //pass in the card contract (which is cRepo)
            // the ioc container, when it comes time to create, it sees the Icardrepository which is needed to make the Card and does so by passing in the CRepo, which we iwll use in all the forthcoming methods.
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cards = await _cRepo.GetCards();
            return View(cards);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //We only have a Get and Post for the Create, but when it comes to the post, we're going to take everything from the view/form and assign them to the create.
        public async Task<IActionResult> Create(CardCreate cardCreate)
        {
            if (ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            if (await _cRepo.AddCard(cardCreate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(cardCreate);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var card = await _cRepo.GetCardbyId(id.Value);
            if (card is null)
            {
                return NotFound();
            }
            return View(card);

        }

        [HttpGet]
        //The get will have 'View' which will give all the information to card and will convert to another form
        public async Task<IActionResult> Edit(int? id)
        {
            var card = await _cRepo.GetCardbyId(id.Value);
            if (card is null)
            {
                return NotFound();
            }
            return View(card);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CardUpdate cardUpdate)
            //The contents inbetween the paranthesis is needed to fulfill the contract, refer to CardRepository line 70 for memory
        {
            if (id != cardUpdate.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //bad request is used in this instance because if color, effect, or rarity is wrong, we want it to tell us!!
            }
            if (await _cRepo.UpdateCard(id, cardUpdate))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(cardUpdate);
            }
        }

        //Before coding 'delete' it will look a lot like edit, as we need a post to perform a delete in the first place
        //The logic happens in 'post'

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var card = await _cRepo.GetCardbyId(id.Value);
            if (card is null)
            {
                return NotFound();
            }
            return View(card);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _cRepo.DeleteCard(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return UnprocessableEntity();
        }
    }
}


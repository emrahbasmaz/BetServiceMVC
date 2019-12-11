using BetService.Models;
using BetService.Repository.Entity;
using BetService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BetService.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayersService playersService;
        public PlayerController(IPlayersService playersService)
        {
            this.playersService = playersService;
        }
        public ActionResult Index()
        {            
            var model = this.playersService.GetAll();
            List<SelectListItem> selectListItems = FillList();
            ViewBag.selectListItems = selectListItems;         

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = this.playersService.GetById(id);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Players players)
        {
            if (players.Email == null)
            {
                ModelState.AddModelError(nameof(players.Email), "Email should be enter...");
            }
            if (players.Name == null)
            {
                ModelState.AddModelError(nameof(players.Name), "Name should be enter...");
            }
            if (ModelState.IsValid)
            {
                this.playersService.Insert(players);
                TempData["Message"] = "Operation Successfull";
                return RedirectToAction("Details", new { id = players.PlayerId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = this.playersService.GetById(id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Players players)
        {
            if (ModelState.IsValid)
            {
                this.playersService.Update(players);
                TempData["Message"] = "Operation Successfull";
                return RedirectToAction("Details", new { id = players.PlayerId });
            }
            return View(players);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = this.playersService.GetById(id);
            if (model == null)
                return View("NotFound");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                this.playersService.Delete(id);
                TempData["Message"] = "Operation Successfull";
                return RedirectToAction("Index");
            }
            return View("NotFound");
        }


        public List<SelectListItem> FillList()
        {
            var list = new List<SelectListItem>();
            try
            {
                var players = this.playersService.GetAll();
                foreach (var item in players)
                    list.Add(new SelectListItem { Text = item.Name, Value = item.PlayerId.ToString() });

                if (players == null)
                    list.Add(new SelectListItem { Text = "No records found", Value = "0" });
            }
            catch (Exception ex)
            {
                list.Add(new SelectListItem { Text = ex.Message.ToString(), Value = "0" });
            }

            return list;
        }
    }
}

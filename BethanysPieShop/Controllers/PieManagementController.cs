﻿using System.Collections.Generic;
using System.Linq;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BethanysPieShop.Controllers
{
    [Authorize(Roles = "Administrators")]
    [Authorize(Policy = "DeletePie")]
    public class PieManagementController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieManagementController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            var pies = _pieRepository.Pies.OrderBy(p => p.PieId);
            return View(pies);
        }

        public IActionResult AddPie()
        {
            var categories = _categoryRepository.Categories;
            var pieEditViewModel = new PieEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().CategoryId
            };
            return View(pieEditViewModel);
        }

        [HttpPost]
        public IActionResult AddPie(PieEditViewModel pieEditViewModel)
        {
            //Basic validation
            if (ModelState.IsValid)
            {
                _pieRepository.CreatePie(pieEditViewModel.Pie);
                return RedirectToAction("Index");
            }
            return View(pieEditViewModel);
        }

        public IActionResult EditPie(int pieId)
        {
            var categories = _categoryRepository.Categories;

            var pie = _pieRepository.Pies.FirstOrDefault(p => p.PieId == pieId);

            var pieEditViewModel = new PieEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                Pie = pie,
                CategoryId = pie.CategoryId
            };

            var item = pieEditViewModel.Categories.FirstOrDefault(c => c.Value == pie.CategoryId.ToString());
            item.Selected = true;

            return View(pieEditViewModel);
        }

        [HttpPost]
        //public IActionResult EditPie([Bind("Pie")] PieEditViewModel pieEditViewModel)
        public IActionResult EditPie(PieEditViewModel pieEditViewModel)
        {
            pieEditViewModel.Pie.CategoryId = pieEditViewModel.CategoryId;
            if (ModelState.IsValid)
            {
                _pieRepository.UpdatePie(pieEditViewModel.Pie);
                return RedirectToAction("Index");
            }
            return View(pieEditViewModel);
        }

        [HttpPost]
        public IActionResult DeletePie(string pieId)
        {
            return View();
        }

        public IActionResult QuickEdit()
        {
            var pieNames = _pieRepository.Pies.Select(p => p.Name).ToList();
            return View(pieNames);
        }

        [HttpPost]
        public IActionResult QuickEdit(List<string> pieNames)
        {
            //Do awesome things with the pie names here
            return View(pieNames);
        }

        public IActionResult BulkEditPies()
        {
            var pieNames = _pieRepository.Pies.ToList();
            return View(pieNames);
        }

        [HttpPost]
        public IActionResult BulkEditPies(List<Pie> pies)
        {
            //Do awesome things with the pie here
            return View(pies);
        }
    }

    public class x
    {
        public void t (int i , bool v=true)
        {

        }
    }
    public class C : x
    {

    }
}
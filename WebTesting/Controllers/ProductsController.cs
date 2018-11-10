using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTesting.Models;
using WebTesting.Service;

namespace WebTesting.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            _service.Create(model);

            return RedirectToAction("Index");
        }
    }
}
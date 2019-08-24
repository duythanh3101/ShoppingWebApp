﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebApp.Application.Interfaces;
using ShoppingWebApp.Data.EF;

namespace ShoppingWebApp.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetAll().ToList());
        }
    }
}
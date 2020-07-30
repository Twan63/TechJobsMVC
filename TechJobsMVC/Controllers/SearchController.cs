﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Models;
using TechJobsMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        public IActionResult Results(string searchType, string searchTerm)
        {

            List<Job> floopSearch;
               
            if (string.IsNullOrEmpty(searchTerm))
            {
               floopSearch  = JobData.FindAll();
                

            }
            else
            {
                floopSearch = JobData.FindByColumnAndValue(searchType, searchTerm);

            }

            ViewBag.Columns = ListController.ColumnChoices;

            ViewBag.Jobs = floopSearch;            
            return View("Index");
        }
    }
}

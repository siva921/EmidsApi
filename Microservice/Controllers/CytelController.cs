using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microservice.Repository;
using Microsoft.Extensions.Configuration;
using Microservice.Models;


namespace Microservice.Controllers
{
    [ApiController]
   // [Route("[controller]")]
    public class CytelController : ControllerBase
    {

        private readonly InputRepository customerRepository;
        public CytelController(IConfiguration configuration)
        {
            customerRepository = new InputRepository(configuration);
        }
        // GET: Cytel
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Cytel/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("Cytel/GetAll")]
        // GET: Cytel/Create
        public IEnumerable<Input> GetAll()
        {
           IEnumerable<Input> listAll= customerRepository.FindAll();
            return listAll;
        }
        [HttpGet]
        [Route("Cytel/GetById")]
        // GET: Cytel/Create
        public Input GetById(int id)
        {
            Input _input = customerRepository.FindByID(id);
            return _input;
        }

        [HttpPost]
        [Route("Cytel/PostInput")]
        public void PostInput(Input _input)
        {
            customerRepository.Add(_input);
        }

        // POST: Cytel/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //// GET: Cytel/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Cytel/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Cytel/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Cytel/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
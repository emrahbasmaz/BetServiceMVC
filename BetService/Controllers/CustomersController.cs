using BetService.Repository.Entity;
using BetService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace BetService.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService customersService;
        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var model = this.customersService.GetAll();
            return View();
        }

        public ActionResult LoadData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data  
                IEnumerable<Customers> customerData = this.customersService.GetAll();

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.ContactName.Contains(searchValue));
                }

                //total number of rows count   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customers customers)
        {
            if (ModelState.IsValid)
            {
                this.customersService.Insert(customers);
                TempData["Message"] = "Operation Successfull";
                //return RedirectToAction("Details", new { id = customers.CustomerID });
            }
            return View();
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var model = this.customersService.GetById(id);
            if (model == null)
                return View("NotFound");

            return View(model);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customers customers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.customersService.Update(customers);
                    TempData["Message"] = "Operation Successfull";
                    return RedirectToAction("Edit", new { id = customers.CustomerID });
                }
                TempData["Message"] = "Invalid Data";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var model = this.customersService.GetById(id);
            if (model == null)
                return View("NotFound");

            return View(model);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customers customers)
        {
            try
            {
                if (customers == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var model = this.customersService.GetById(customers.CustomerID);
                if (model != null)
                {
                    this.customersService.Delete(model);
                    TempData["Message"] = "Operation Successfull";
                    //return RedirectToAction("Delete", new { id = customers.CustomerID });
                    return RedirectToAction("Index");
                }
                TempData["Message"] = "Invalid Data";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int ID)
        {
            if (ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = this.customersService.GetById(ID);
            if (model != null)
            {
                this.customersService.Delete(ID);
                this.customersService.Save();
                TempData["Message"] = "Operation Successfull";
            }
            else
                return HttpNotFound();

            return RedirectToAction("Index");
            //return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
        }

    }
}

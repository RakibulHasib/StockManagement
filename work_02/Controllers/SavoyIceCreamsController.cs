using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using work_02.Models;
using work_02.ViewModel;

namespace work_02.Controllers
{
    public class SavoyIceCreamsController : Controller
    {
        private IceCreamDbContext db = new IceCreamDbContext();

        // GET: SavoyIceCreams
        public ActionResult Index()
        {
            var savoyIceCream = db.SavoyIceCream.Include(s => s.ProductCategory);
            return View(savoyIceCream.ToList());
        }


        public ActionResult Create()
        {
            List<SavoyIceCreamViewModel> savoyIceCreamViewModels = new List<SavoyIceCreamViewModel>();
            savoyIceCreamViewModels.Add(new SavoyIceCreamViewModel()); // Add an initial item to the list
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategory, "ProductCategoryID", "ProductName");
            return View(savoyIceCreamViewModels);
        }

        public ActionResult GetProductCategories()
        {
            var categories = db.ProductCategory.ToList();
            var categoryList = categories.Select(c => new
            {
                Value = c.ProductCategoryID,
                Text = c.ProductName
            }).ToList();
            return Json(categoryList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult CreateIceCream(List<SavoyIceCreamViewModel> savoyVM)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in savoyVM)
                {
                    var savoyIceCream = new SavoyIceCream()
                    {
                        ProductCategoryID = item.ProductCategoryId,
                        Price = item.Price,
                        Eja = item.Eja,
                        NewProduct = item.NewProduct,
                        Total = item.Total,
                        SalesQuantity = item.SalesQuantity,
                        TotalAmount = item.TotalAmount,
                        Return = item.Return,
                        Remaining = item.Remaining,
                        CreatedDate = DateTime.Now
                    };

                    db.SavoyIceCream.Add(savoyIceCream);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("_success");
        }


        public ActionResult GetPreviousDayEjaByCategory(int productCategoryID)
        {
            var eja = db.SavoyIceCream
                .Where(e => e.ProductCategoryID == productCategoryID)
                .OrderByDescending(e => e.CreatedDate)
                .Select(e => e.Eja)
                .FirstOrDefault();

            return Json(eja, JsonRequestBehavior.AllowGet);
        }



    }
}

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace work_02.ViewModel
{
    public class SavoyIceCreamViewModel
    {
        public int SavoyIceCreamId { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Price { get; set; }
        public int? Eja { get; set; }
        public int? NewProduct { get; set; }
        public int? Total { get; set; }
        public int? SalesQuantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? Return { get; set; }
        public int? Remaining { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IEnumerable<SelectListItem> ProductCategories { get; set; }
    }
}
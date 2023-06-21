using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace work_02.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string ProductName { get; set; }
        public virtual ICollection<SavoyIceCream> SavoyIceCreams { get; set; } = new HashSet<SavoyIceCream>();
    }
    public class SavoyIceCream
    {
        public int SavoyIceCreamId { get; set; }
        [ForeignKey("ProductCategory")]
        public int ProductCategoryID { get; set; }
        public int? Eja { get; set; }
        public decimal Price { get; set; }
        public int? NewProduct { get; set; }
        public int? Total { get; set; }
        public int? SalesQuantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? Return { get; set; }
        public int? Remaining { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
    public class IceCreamDbContext : DbContext
    {
        public IceCreamDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IceCreamDbContext>());
        }
        public DbSet<SavoyIceCream> SavoyIceCream { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
    }

}
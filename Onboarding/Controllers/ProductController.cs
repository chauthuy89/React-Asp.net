using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Onboarding.Models;
using Newtonsoft.Json;

namespace Onboarding.Controllers
{
    public class ProductController : Controller
    {
        readonly private TalentOnboardingEntities1 db;

        public ProductController()
        {
            db = new TalentOnboardingEntities1();
        }

        // GET: Customer
        public JsonResult GetProduct()
        {
            try
            {
                var productList = db.Products.Select(x=>new { x.ProductID, x.Name, x.Price }).ToList();
                return new JsonResult { Data = productList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Data Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
        }

        //Create Customer
        public JsonResult CreateProduct(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Create Product Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Product created", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //Update Customer
        public JsonResult UpdateProduct(Product product)
        {
            try
            {
                Product dbProduct = db.Products.Where(x => x.ProductID == product.ProductID).SingleOrDefault();
                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Update Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Product details updated", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        //GetUpdate Customer
        public JsonResult GetUpdateProduct(int id)
        {
            try
            {
                Product product = db.Products.Where(x => x.ProductID == id).SingleOrDefault();
                return new JsonResult { Data = product, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Product Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //Delete Product
        public JsonResult DeleteProduct(int id)
        {
            try
            {
                var product = db.Products.Where(x => x.ProductID == id).SingleOrDefault();
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Deletion Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            return new JsonResult { Data = "Success Product Deleted", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public ActionResult Index()
        {
            return View();
        }


    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onboarding.Models;

namespace Onboarding.Controllers
{
    public class StoreController : Controller
    {
        readonly private TalentOnboardingEntities1 db;

        public StoreController()
        {
            db = new TalentOnboardingEntities1();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET Stores
        public JsonResult GetStore()
        {
            try
            {
                var storeList = db.Stores.Select(x=> new { x.StoreID, x.Name, x.Address}).ToList();
                return new JsonResult { Data = storeList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Data Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // DELETE Store
        public JsonResult DeleteStore(int id)
        {
            try
            {
                var store = db.Stores.Where(s => s.StoreID == id).SingleOrDefault();
                if (store != null)
                {
                     db.Stores.Remove(store);
                     db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Deletion Falied", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // CREATE Store
        public JsonResult CreateStore(Store store)
        {
            try
            {
                db.Stores.Add(store);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Store Create Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // UPDATE Store
        public JsonResult GetUpdateStore(int id)
        {
            try
            {
                Store store = db.Stores.Where(s => s.StoreID == id).SingleOrDefault();
                return new JsonResult { Data = store, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Store Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult UpdateStore(Store store)
        {
            try
            {
                Store st = db.Stores.Where(s => s.StoreID == store.StoreID).SingleOrDefault();
                st.Name = store.Name;
                st.Address = store.Address;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Store Update Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
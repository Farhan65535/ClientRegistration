using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientRegistration.Models;

namespace ClientRegistration.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Clients.ToList());
            }
                return View();
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModels =new DbModels())
            {
                return View(dbModels.Clients.Where(x => x.ClientID == id).FirstOrDefault());
            }
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Clients.Add(client);
                    dbModels.SaveChanges();
                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Clients.Where(x => x.ClientID == id).FirstOrDefault());
            }

            return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Client client)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Entry(client).State = EntityState.Modified;
                    dbModels.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Clients.Where(x => x.ClientID == id).FirstOrDefault());
            }
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using(DbModels dbModels = new DbModels())
                {
                    Client client = dbModels.Clients.Where((x) => x.ClientID == id).FirstOrDefault();
                    dbModels.Clients.Remove(client);
                    dbModels.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

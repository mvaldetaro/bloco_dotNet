using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    public class FriendsController : Controller
    {
        // GET: Friends
        public ActionResult Index()
        {

            var repository = new FriendsRepository();

            var friends = repository.GetAllFriends();

            return View(
                friends.Select(a => new FriendViewModel {
                    Id = a.FriendId,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthDate =a.BirthDate

                }));
        }

        // GET: Friends/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Friends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friends/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Friends/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friends/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Friends/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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

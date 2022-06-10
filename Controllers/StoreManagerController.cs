using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMusicStore.Models;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace MvcMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        MusicStoreContext context = new MusicStoreContext();

        // GET: StoreManager
        public ActionResult Index()
        {
            return View(context.AllAlbums.Include("Artist").Include("Genre").ToList());
        }

        public ActionResult CreateNewAlbum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewAlbum(Album a)
        {
            MusicStoreContext context = new MusicStoreContext();
            context.AllAlbums.Add(a);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditAlbum(string title)
        {
            MusicStoreContext context = new MusicStoreContext();
            var albumtoedit = context.AllAlbums.Include("Artist").Include("Genre").Where(a => a.Title == title).SingleOrDefault();
            return View(albumtoedit);
        }

        [HttpPost]
        public ActionResult EditAlbum(Album a)
        {
            MusicStoreContext context = new MusicStoreContext();
            context.Entry(a).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAlbum(string title)
        {
            MusicStoreContext context = new MusicStoreContext();

            var albumtodelete = context.AllAlbums.Where(a => a.Title == title).SingleOrDefault();
            context.AllAlbums.Remove(albumtodelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
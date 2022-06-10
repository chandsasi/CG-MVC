using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreContext context = new MusicStoreContext();
        // GET: Strore
        /* public ActionResult Index()
         {
             return View();
         }*/

        public ActionResult Index()
        {
            //var genres = new List<Genre>()
            //{
            //    new Genre{GenreName="Disco"},
            //    new Genre{GenreName="Rock"},
            //    new Genre{GenreName="Jazz"},
            //};
            //return View(genres);

            var genres = context.AllGenres.ToList();
            ViewBag.GenresList = new SelectList(genres, "GenreId", "GenreName");

            return View(genres);

        }

        public ActionResult Browse(string genre)
        {
            var genreModel = context.AllGenres.Include("Albums").Where(g =>
                g.GenreName == genre).Single();
            return View(genreModel);

            //var genreModel = new Genre { GenreName = genre };
            //return View(genreModel);
        }

        [HttpPost]
        public ActionResult Browse(int genre)
        {
            var genreModel = context.AllGenres.Include("Albums").Where(g =>
                g.GenreId == genre).Single();
            return View(genreModel);

            //var genreModel = new Genre { GenreName = genre };
            //return View(genreModel);
        }

        public ActionResult Details(string id)
        {
            var album = context.AllAlbums.Find(id);
            return View(album);

            //var album = new Album { Title = "Album " + id };
            //return View(album);
        }

        //public string Browse(string genre)
        //{
        //    string message = "Store.Browse(), Genre = " + genre;
        //    return message;
        //}

        //public string Details(int id)
        //{
        //    string message = "Store.Details(), ID = " + id;
        //    return message;
        //}

        //public string Browse()
        //{
        //    return "Hello from Store.Browse()";
        //}

        //public string Details()
        //{
        //    return "Hello from Store.Details()";
        //}

    }
}
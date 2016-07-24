using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVC001.DAL;
using MVC001.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;
using System;
using MVC001.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace MVC001.Controllers
{
    public class AuthorsController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Authors
        public ActionResult Index([Form] QueryOptions queryOptions)
        {
            //var authors = db.Authors.OrderByDescending(a=>a.FirstName).ToList();

            //var authors = db.Authors.OrderBy(queryOptions.Sort);

            var start = (queryOptions.CurrentPage - 1) * queryOptions.PageSize;
            var authors = db.Authors
                .OrderBy(queryOptions.Sort)
                .Skip(start)
                .Take(queryOptions.PageSize);

            queryOptions.TotalPages = (int)Math.Ceiling((double)db.Authors.Count() / queryOptions.PageSize);

            ViewBag.QueryOptions = queryOptions;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorViewModel>();
            });

            var mapper = mapperConfig.CreateMapper();

            var authorViewModelList = mapper.Map<IList<Author>, IList<AuthorViewModel>>(authors.ToList());

            return View(authorViewModelList);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorViewModel>();
            });

            var mapper = mapperConfig.CreateMapper();

            return View(mapper.Map<Author,AuthorViewModel>(author));
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View("Form",new AuthorViewModel());
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Biography")] AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                var mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AuthorViewModel,Author>();
                });

                var mapper = mapperConfig.CreateMapper();

                db.Authors.Add(mapper.Map<AuthorViewModel,Author>(author));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorViewModel>();
            });

            var mapper = mapperConfig.CreateMapper();


            return View("Form",mapper.Map<Author,AuthorViewModel>(author));
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Biography")] AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                var mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AuthorViewModel, Author>();
                });

                var mapper = mapperConfig.CreateMapper();


                db.Entry(mapper.Map<AuthorViewModel,Author>(author)).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author,AuthorViewModel>();
            });

            var mapper = mapperConfig.CreateMapper();

            return View(mapper.Map<Author,AuthorViewModel>(author));
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

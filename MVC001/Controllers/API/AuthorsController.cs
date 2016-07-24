using MVC001.DAL;
using MVC001.ViewModels;
using System.Web.Http;
using System.Linq;
using System.Linq.Dynamic;
using System;
using System.Collections.Generic;
using AutoMapper;
using MVC001.Models;

namespace MVC001.Controllers.API
{
    public class AuthorsController : ApiController
    {
        private BookContext db = new BookContext();

        public ResultList<AuthorViewModel> Get([FromUri] QueryOptions queryOptions)
        {
            var start = (queryOptions.CurrentPage - 1) * queryOptions.PageSize;

            var authors = db.Authors
                .OrderBy(queryOptions.SortField)
                .Skip(start)
                .Take(queryOptions.PageSize);

            queryOptions.TotalPages = (int)Math.Ceiling((double)db.Authors.Count() / queryOptions.PageSize);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorViewModel>();
            });

            var mapper = mapperConfig.CreateMapper();

            return new ResultList<AuthorViewModel>
            {
                QueryOptions = queryOptions,
                Results = mapper.Map<List<Author>, List<AuthorViewModel>>(authors.ToList())
            };
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
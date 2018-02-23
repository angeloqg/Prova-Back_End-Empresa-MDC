using System;
using System.Collections.Generic;
using System.Linq;
using DataLogic.DataList;
using DataLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using static DataLogic.DataList.ModelData;

namespace ServerLocation.Controllers
{
    [Produces("application/json")]
    [Route("Country/result")]
    public class CountryController : Controller
    {
        private readonly BaseContext _context;
        private DataQuery query;

        // Using Dependency Injection for DAL and BLL
        public CountryController(BaseContext context)
        {
            _context = context;
            query = new DataQuery(_context);
        }

        // GET Country/result
        [HttpGet()]
        public List<ModelDataContry> Get()
        {
            return query.countryListing();
        }

        // GET Country/result/{id}
        [HttpGet("{id}")]
        public List<ModelDataContry> Get(int? id)
        {
            var resultado = new List<ModelDataContry>();
            int valor = 0;

            if (id != null)
            {
                if (Int32.TryParse(id.ToString(), out valor))
                {
                    resultado = query.countryListing().Where(i => i.idCountry == valor).ToList();
                }
            }

            return resultado;
        }
    }
}
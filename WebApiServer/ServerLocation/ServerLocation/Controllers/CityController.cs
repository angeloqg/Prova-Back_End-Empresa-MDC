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
    [Route("City/Result")]
    public class CityController : Controller
    {
        private readonly BaseContext _context;
        private DataQuery query;

        // Using Dependency Injection for DAL and BLL
        public CityController(BaseContext context)
        {
            _context = context;
            query = new DataQuery(_context);
        }

        // GET City/result
        [HttpGet()]
        public List<ModelDataCity> Get()
        {
            return query.cityListing();
        }

        // GET City/result/{id}
        [HttpGet("{id}")]
        public List<ModelDataCity> Get(int? id)
        {
            var resultado = new  List<ModelDataCity>();
            int valor = 0;

            if (id != null)
            {
                if(Int32.TryParse(id.ToString(), out valor))
                {
                    resultado = query.cityListing().Where(i => i.idCity == valor).ToList();
                }
            }

            return resultado;
        }
    }
}
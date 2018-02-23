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
    [Route("State/result")]
    public class StateController : Controller
    {
        private readonly BaseContext _context;
        private DataQuery query;

        // Using Dependency Injection for DAL and BLL
        public StateController(BaseContext context)
        {
            _context = context;
            query = new DataQuery(_context);
        }

        // GET State/result
        [HttpGet()]
        public List<ModelDataState> Get()
        {
            return query.stateListing();
        }

        // GET State/result/{id}
        [HttpGet("{id}")]
        public List<ModelDataState> Get(int? id)
        {
            var resultado = new List<ModelDataState>();
            int valor = 0;

            if (id != null)
            {
                if (Int32.TryParse(id.ToString(), out valor))
                {
                    resultado = query.stateListing().Where(i => i.idState == valor).ToList();
                }
            }

            return resultado;
        }
    }
}
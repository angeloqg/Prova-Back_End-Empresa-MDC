using System.Collections.Generic;
using System.Linq;
using DataLogic.Entities;
using static DataLogic.DataList.ModelData;

namespace DataLogic.DataList
{
    public class DataQuery
    {
        private BaseContext _context;

        public DataQuery(BaseContext context)
        {
            _context = context;

            initialize();
        }


        #region Initialize new database
        private void initialize()
        {
            var tbCity = _context.City;
            var tbContry = _context.Country;
            var tbState = _context.State;

            try
            {

                if (tbContry != null && tbContry.Count() == 0)
                {
                    _context.Country.AddRange(new Country { nameCountry = "Brazil" },
                                              new Country { nameCountry = "United State" });

                    _context.SaveChanges();

                    int idCountry = 0;

                    if (tbState != null && tbState.Count() == 0 && tbContry.Count() > 0)
                    {
                        idCountry = _context.Country.Where(i => i.nameCountry.Equals("Brazil")).FirstOrDefault().idCountry;

                        _context.State.AddRange(new State { nameState = "Rio de Janeiro", idCountry = idCountry },
                                                new State { nameState = "São Paulo", idCountry = idCountry },
                                                new State { nameState = "Minas Gerais", idCountry = idCountry },
                                                new State { nameState = "Bahia", idCountry = idCountry });

                        idCountry = _context.Country.Where(i => i.nameCountry.Equals("United State")).FirstOrDefault().idCountry;

                        _context.State.AddRange(new State { nameState = "Massachusetts", idCountry = idCountry },
                                                new State { nameState = "Washington", idCountry = idCountry },
                                                new State { nameState = "Texas", idCountry = idCountry },
                                                new State { nameState = "Nova Iorque", idCountry = idCountry });

                        _context.SaveChanges();

                    }

                    int idState = 0;

                    if (tbCity != null && tbCity.Count() == 0 && tbState.Count() > 0)
                    {
                        idState = _context.State.Where(i => i.nameState.Equals("Rio de Janeiro")).FirstOrDefault().idState;

                        _context.City.AddRange(new City { nameCity = "Rio de Janeiro", idState = idState },
                                               new City { nameCity = "Niterói", idState = idState },
                                               new City { nameCity = "Cabo Frio", idState = idState },
                                               new City { nameCity = "Petrópolis", idState = idState });

                        idState = _context.State.Where(i => i.nameState.Equals("São Paulo")).FirstOrDefault().idState;

                        _context.City.AddRange(new City { nameCity = "São Paulo", idState = idState },
                                               new City { nameCity = "Sorocaba", idState = idState },
                                               new City { nameCity = "Santos", idState = idState },
                                               new City { nameCity = "Guarulhos", idState = idState });

                        idState = _context.State.Where(i => i.nameState.Equals("Minas Gerais")).FirstOrDefault().idState;

                        _context.City.AddRange(new City { nameCity = "Belo Horizonte", idState = idState },
                                               new City { nameCity = "Juíz de Fora", idState = idState },
                                               new City { nameCity = "Caldas", idState = idState },
                                               new City { nameCity = "Uberlândia", idState = idState });

                        idState = _context.State.Where(i => i.nameState.Equals("Bahia")).FirstOrDefault().idState;

                        _context.City.AddRange(new City { nameCity = "Salvador", idState = idState },
                                               new City { nameCity = "Porto Seguro", idState = idState },
                                               new City { nameCity = "Juazeiro", idState = idState },
                                               new City { nameCity = "Ilhéus", idState = idState });

                        _context.SaveChanges();
                    }
                }
            }
            catch
            {
                // -- No action
            }
        }

        #endregion
        #region Generates data object query result

        public List<ModelDataCity> cityListing()
        {
            var list = new List<ModelDataCity>();

            try
            {
                var query = (from c in _context.Country
                             join s in _context.State on c.idCountry equals s.idCountry
                             join t in _context.City on s.idState equals t.idState
                             select new
                             {
                                 idCity = t.idCity,
                                 nameCity = t.nameCity,
                                 nameState = s.nameState,
                                 nameCountry = c.nameCountry
                             }).ToList();


                foreach (var item in query)
                {
                    var data = new ModelDataCity();

                    data.idCity = item.idCity;
                    data.city = item.nameCity;
                    data.state = item.nameState;
                    data.contry = item.nameCountry;

                    list.Add(data);
                }
            }
            catch
            {
                // -- No Action
            }

            return list;
        }

        public List<ModelDataState> stateListing()
        {
            var list = new List<ModelDataState>();

            try
            {
                var query = (from c in _context.Country
                             join s in _context.State on c.idCountry equals s.idCountry
                             select new
                             {
                                 idState = s.idState,
                                 nameState = s.nameState,
                                 nameCountry = c.nameCountry
                             }).ToList();

                foreach (var item in query)
                {
                    var data = new ModelDataState();

                    data.idState = item.idState;
                    data.state = item.nameState;
                    data.contry = item.nameCountry;

                    list.Add(data);
                }
            }
            catch
            {
                // -- No action
            }

            return list;
        }

        public List<ModelDataContry> countryListing()
        {
            var list = new List<ModelDataContry>();

            try
            {
                var query = _context.Country.ToList();

                foreach (var item in query)
                {
                    var data = new ModelDataContry();

                    data.idCountry = item.idCountry;
                    data.contry = item.nameCountry;

                    list.Add(data);
                }
            }
            catch
            {
                // no action
            }

            return list;
        }

        #endregion
    }
}

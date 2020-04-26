using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T882292.Models;

namespace T882292.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DataGridStatesWithCitiesController : Controller
    {

        [HttpGet]
        public object Get(int StateID, DataSourceLoadOptions loadOptions)
        {
            if (StateID == 0)
            {
                return DataSourceLoader.Load(SampleData.StatesWithCities, loadOptions);
            }

            var distinctStateIDs = SampleData.DataGridEmployeesByState.Where(i => i.StateID.HasValue).Select(i => i.StateID).Distinct();
            var results = SampleData.StatesWithCities.Where(x => !distinctStateIDs.Contains(x.ID) || x.ID.Equals(StateID));

            return Json(DataSourceLoader.Load(results, loadOptions));
        }
    }
}
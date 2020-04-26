using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using T882292.Models;

namespace T882292.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DataGridEmployeesByStateController : Controller
    {

        public DataGridEmployeesByStateController()
        {
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(SampleData.DataGridEmployeesByState, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newEmployee = new EmployeeByState();
            JsonConvert.PopulateObject(values, newEmployee);

            SampleData.DataGridEmployeesByState.Add(newEmployee);

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var employee = SampleData.DataGridEmployeesByState.First(a => a.ID == key);
            JsonConvert.PopulateObject(values, employee);


            return Ok();
        }

        //[HttpDelete]
        //public void Delete(int key)
        //{
        //    var employee = _data.EmployeesByState.First(a => a.ID == key);
        //    _data.EmployeesByState.Remove(employee);
        //    _data.SaveChanges();
        //}
    }
}
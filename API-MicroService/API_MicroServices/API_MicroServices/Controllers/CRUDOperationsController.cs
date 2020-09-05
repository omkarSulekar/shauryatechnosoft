using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_MicroServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Web;

namespace API_MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDOperationsController : ControllerBase
    {
        CRUDOperations operations = new CRUDOperations();
        // GET: api/CRUDOperations
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CRUDOperations/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CRUDOperations
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CRUDOperations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("SaveUser")]
        [HttpPost]
        public string SaveUser([FromForm]User user)
        {
            #region Upload File
            String PhotoPath = string.Empty;
            //HttpFileCollection MyFileCollection = Request.Files;
            IFormFileCollection files = Request.Form.Files;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(@"D:\docs", formFile.FileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        formFile.CopyToAsync(stream);
                    }
                    PhotoPath = filePath;
                }
            }
            #endregion
            user.Photopath = PhotoPath;
            bool isSaved = operations.InsertRecord(user);
            return isSaved ? "saved" : "No Saved";
        }

        [Route("SearchVehicle")]
        [HttpPost]
        public IEnumerable<Vehicle> SearchVehicle([FromForm]searchModel searchModel)
        {
         
            List<Vehicle> lstVehicle = new List<Vehicle>();
            lstVehicle = operations.GetVehicleList(searchModel);
            return lstVehicle;
        }
    }
}

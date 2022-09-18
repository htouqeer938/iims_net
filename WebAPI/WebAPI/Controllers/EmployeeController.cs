using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;
using Microsoft.Extensions.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                string query = @"select * from Employee";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("IIMSAppCon");
                SqlDataReader myReader;
                using (SqlConnection con = new SqlConnection(sqlDataSource))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        myReader = cmd.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        con.Close();
                    }
                    Console.WriteLine("Table", table);
                    return new JsonResult(table);
                }
            }
            catch(Exception)
            {
                return new JsonResult("Some Erro in API");
            }
        }
    }
}

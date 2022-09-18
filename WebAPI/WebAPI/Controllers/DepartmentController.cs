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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Get All Method
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Department";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IIMSAppCon");
            SqlDataReader myReader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {   
                con.Open();
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    con.Close();
                }
                return new JsonResult(table);
            }
        }

        // Get One by ID method
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"select * from Department where DepartmentId = "+ id +@"";
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
                return new JsonResult(table);
            }
        }

        // Insert Method
        [HttpPost]
        public JsonResult Post(Department dep)
        {
            string query = @"
                insert into Department values ('"+ dep.DepartmentName +@"')
            ";
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
                return new JsonResult("Department created successfully!");
            }
        }

        // Update Method
        [HttpPut("{id}")]
        public JsonResult Put(Department dep, int id)
        {
            string query = @"
                update Department set DepartmentName = ('" + dep.DepartmentName + @"') where DepartmentId = " + id + @"
            ";
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
                return new JsonResult("Department updated successfully!");
            }
        }

        // Delete Method
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from Department where DepartmentId = " + id + @"
            ";
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
                return new JsonResult("Department deleted successfully!");
            }
        }
    }
}

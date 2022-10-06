using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;

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

        // Get All Employees method
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
                    return new JsonResult(table);
                }
            }
            catch (Exception)
            {
                return new JsonResult("Some Erro in API");
            }
        }

        // Get One Employee method
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                string query = @"select * from Employee where EmployeeId = '" + id + @"'";
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
            catch (Exception)
            {
                return new JsonResult("Some Error in API");
            }
        }

        // insert Employee method
        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            try
            {
                string query = @"insert into Employee (EmployeeName, Department, DateOfJoining, PhotoFileName) values ('" + emp.EmployeeName + @"','" + emp.Department + @"','" + emp.DateOfJoining + @"','" + emp.PhotoFileName + @"')";
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
                    return new JsonResult("Employee created successfully");
                }
            }
            catch (Exception)
            {
                return new JsonResult("Some Erro in API");
            }
        }

        // Update Employee method
        [HttpPut("{id}")]
        public JsonResult Put(Employee emp, int id)
        {
            try
            {
                string query = @"update Employee set EmployeeName = '" + emp.EmployeeName + @"', Department = '" + emp.Department + @"', DateOfJoining = '" + emp.DateOfJoining + @"', PhotoFileName = '" + emp.PhotoFileName + @"' where EmployeeId = '" + id + @"'";
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
                    return new JsonResult("Update Successfully");
                }
            }
            catch (Exception)
            {
                return new JsonResult("Some Error in API");
            }
        }

        // Employee Delete method
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                string query = @"delete from Employee where EmployeeId = '" + id + @"'";
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
                    return new JsonResult("Employee deleted successfully");
                }
            }
            catch (Exception)
            {
                return new JsonResult("Some Error in API");
            }
        }
    }
}

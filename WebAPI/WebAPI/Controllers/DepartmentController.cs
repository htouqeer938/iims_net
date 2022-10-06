using Microsoft.AspNetCore.Mvc;
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
            try
            {
                string query = @"select * from Department";
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

        // Get One by ID method
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                string query = @"select * from Department where DepartmentId = " + id + @"";
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

        // Insert Method
        [HttpPost]
        public JsonResult Post(Department dep)
        {
            try
            {
                string query = @"
                    insert into Department values ('" + dep.DepartmentName + @"')
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
            catch (Exception)
            {
                return new JsonResult("Some Erro in API");
            }
        }

        // Update Method
        [HttpPut("{id}")]
        public JsonResult Put(Department dep, int id)
        {
            try
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
            catch (Exception)
            {
                return new JsonResult("Some Erro in API");
            }
        }

        // Delete Method
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
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
            catch (Exception)
            {
                return new JsonResult("Some Erro in API");
            }
        }
    }
}

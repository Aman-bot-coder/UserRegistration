using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IConfiguration _Configuration;
        public UserController(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        [HttpPost]
        [Route("/regis")]

        public string model1(Model1 model1)
        {
            SqlConnection conn = new SqlConnection(_Configuration.GetConnectionString("TestOne").ToString());
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration(UserName ,Password,Email,isActive) VALUES('" + model1.UserName+ "','" +model1.Password+ "','" +model1.Email+ "','" +model1.isActive+ "')", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return "Data Inserted";
            }
            else
            {
                return "Error";
            }
            return "";
        }


    }
}

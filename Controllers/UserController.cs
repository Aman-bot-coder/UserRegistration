using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        [Route("/login")]
        public string login(Model1 model1)
        {
            SqlConnection conn = new SqlConnection(_Configuration.GetConnectionString("TestOne").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from Registration WHERE Email='" + model1.Email + "' and Password='" + model1.Password + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return "Valid User";
            }
            else
            {
                return "Invalid User";
            }
        }



    }
}

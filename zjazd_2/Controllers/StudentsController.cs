using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Zadanie_2.Models;
using System.Data.SqlClient;

namespace Zadanie_2.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s15157;Integrated Security=True";
        
        /*
         * HttpGet, -> Pobierz z 80
         * HttpPost, -> Dodaj zasób do BD
         * HttpPut, -> Zaktualizuj zasób
         * HttpPatch,-> Załataj (częsciowa aktualizacja)
         * HttpDelete -> Usuń zasób
         */


        //Zadanie 4.4
        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT IndexNumber, FirstName, LastName, BirthDate, Semester, Name FROM Student s INNER JOIN Enrollment e ON s.IdEnrollment=e.IdEnrollment INNER JOIN Studies st ON e.IdStudy=st.IdStudy;";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    st.Name = dr["Name"].ToString();

                    list.Add(st);
                }

            }
            return Ok(list);
            
        }

        //Zadanie 4.3
        [HttpGet("{id}")]
        public IActionResult GetEnrollment(string id)
        {
            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT IndexNumber, Semester FROM Student s INNER JOIN Enrollment e ON s.IdEnrollment=e.IdEnrollment WHERE IndexNumber='" + id + "';";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();

                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.Semester = dr["Semester"].ToString();

                    list.Add(st);
                }

            }
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        //Zadanie nr.7

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {

            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Usuwanie ukończone");
        }
    }
}
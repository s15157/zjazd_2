using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Zadanie_2.Models;

namespace Zadanie_2.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : Controller
    {
        /*
         * HttpGet, -> Pobierz z 80
         * HttpPost, -> Dodaj zasób do BD
         * HttpPut, -> Zaktualizuj zasób
         * HttpPatch,-> Załataj (częsciowa aktualizacja)
         * HttpDelete -> Usuń zasób
         */

        [HttpGet]
        public string GetStudents([FromQuery] string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudnetById(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("Nie znaleziono studenta");
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
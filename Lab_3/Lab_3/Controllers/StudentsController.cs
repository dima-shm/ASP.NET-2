using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Lab_3.Models;

namespace Lab_3.Controllers
{
    public class StudentsController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        [Route("api/Students/getAll")]
        public IHttpActionResult GetStudents()
        {
            return Ok(db.Students.ToList());
        }

        [Route("api/Students/search")]
        public IHttpActionResult SearchStudents(JObject sParams)
        {
            var students = new List<Student>();
            const int defaultLimit = 50;
            if (sParams == null)
                BadRequest();
            var name = (string) sParams["name"];
            var phone = (string) sParams["phone"];
            var columns = ((string) sParams["columns"]).Split(',');
            var offset = (int) sParams["offset"];
            var limit = ((int)sParams["limit"]) == 0 ? defaultLimit : (int)sParams["limit"];
            var globalike = ((string) sParams["globalike"]) == "on";
            var orderBy = (string)sParams["orderby"] == string.Empty ? "Id" : (string)sParams["orderby"];
            var sqlQuery = string.Empty;

            if (!globalike)
            {
                sqlQuery = "SELECT * FROM Students " +
                    "WHERE Name = @P0 AND Phone = @P1 " +
                    "ORDER BY " + orderBy + " " +
                    "OFFSET @P2 ROWS FETCH NEXT @P3 ROWS ONLY";
            }
            else
            {
                sqlQuery = "SELECT * FROM Students " +
                    "WHERE Name LIKE '%' + @P0 + '%' AND Phone LIKE '%' + @P1 + '%' " +
                    "ORDER BY " + orderBy + " " +
                    "OFFSET @P2 ROWS FETCH NEXT @P3 ROWS ONLY";
            }
            students = db.Students.SqlQuery(sqlQuery, name, phone, offset, limit).ToList();

            if (columns.Contains("name") && columns.Contains("phone"))
                return Ok(students);
            if (columns.Contains("name"))
                return Ok(students.Select(x => new Student() { Id = x.Id, Name = x.Name }));
            if (columns.Contains("phone"))
                return Ok(students.Select(x => new Student() { Id = x.Id, Phone = x.Phone }));
            if (columns.Contains("id") && columns.Count() == 1)
                return Ok(students.Select(x => new Student() { Id = x.Id}));
            return Ok(students);
        }
        
        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student;
            try
            {
                student = db.Students.Find(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (InvalidOperationException e)
            {        
            }
            return NotFound();
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.Id)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("Students", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.Id == id) > 0;
        }
    }
}
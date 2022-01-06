using CollegeLinqToSql.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollegeLinqToSql.Controllers.api
{
    public class ValuesController : ApiController
    {
        static string connetionString = "Data Source=LAPTOP-K0H6TSU4;Initial Catalog=CollegeDB;Integrated Security=True;Pooling=False";
        static DataClasses1DataContext context = new DataClasses1DataContext(connetionString);
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            List<Student> students = new List<Student>();
            try
            {
                foreach(var item in context.Students)
                  {
                Student student1 = new Student();
                student1.Id = item.Id;
                student1.FirstName = item.FirstName;
                student1.LastName = item.LastName;
                student1.Birthday = item.Birthday;
                student1.Email = item.Email;
                student1.SchoolYear = item.SchoolYear;
                students.Add(student1);
                  }
                 return Ok(students);
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex) 
            {
                return Ok(ex.Message);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
             var GetById = context.Students.First(item => item.Id == id);
             return Ok(GetById);

            }
            catch(SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch(Exception)
            {
                return Ok("PLEASE TRY AGAIN");
            }
            
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Student value)
        {
            try
            {
            context.Students.InsertOnSubmit(value);
            context.SubmitChanges();
            return Ok(value);
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] Student value)
        {
            try
            {
             Student GetById = context.Students.First(item => item.Id == id);
             GetById.FirstName = value.FirstName;
             GetById.LastName = value.LastName;
             GetById.Birthday = value.Birthday;
             GetById.Email = value.Email;
             GetById.SchoolYear = value.SchoolYear;
             context.SubmitChanges();
             return Ok(GetById);
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
            context.Students.DeleteOnSubmit(context.Students.First(item => item.Id == id));
            context.SubmitChanges();
            return Ok();
            }
            catch (SqlException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
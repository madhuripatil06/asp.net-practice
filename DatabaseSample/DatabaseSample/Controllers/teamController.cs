using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Data.SqlClient;
using Sql;
using System.Configuration;

namespace DatabaseSample.Controllers
{
    public class teamController : ApiController
    {
        sqlQuery operations =  new sqlQuery();
        private SqlConnection createConnetion()
        {
            var con = ConfigurationManager.ConnectionStrings["teamTable"].ConnectionString;
            return new SqlConnection(con);
        }

        private IHttpActionResult executeQuery(SqlConnection connection, SqlCommand command, String message)
        {
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
                return Ok(message);
            }
            catch
            {
                return NotFound();
            }
            finally
            {
                connection.Close();
            }

        }



        [HttpGet]
        [Route("api/team")]
        public IHttpActionResult Getteams()
        {
            string queryString = "SELECT username, count FROM dbo.team;";
            using (SqlConnection connection = createConnetion())
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<Object> array = new List<Object>();
                try
                {
                    
                    while (reader.Read())
                    {
                        Dictionary<String, Object> record =  new Dictionary<String, Object>();
                        record["username"] = reader[0];
                        record["count"] = reader[1];
                        array.Add(record);
                    }
                    return Ok(array.ToArray());
                }
                catch
                {
                    return Ok("Not selected");
                }
                finally
                {
                    reader.Close();
                    connection.Close();
                }
            }
        }

        [HttpPost]
        [Route("api/team/{username}/{count}")]
        public IHttpActionResult AddMember(string username, int count)
        {
            string queryString = "INSERT INTO dbo.team(username, count) VALUES(@username, @count);";
            using (SqlConnection connection = createConnetion())
            {
                SqlCommand command = operations.QueryWith2Attr(username, count);
                command.Connection = connection;
                command.CommandText = queryString;
                return executeQuery(connection, command, "inserted");
            }
        }


        [HttpPut]
        [Route("api/team/{username}/{count}")]
        public IHttpActionResult EditMember(string username, int count)
        {
            string queryString = "UPDATE dbo.team SET count= @count WHERE username=@username";
            using (SqlConnection connection = createConnetion())
            {
                SqlCommand command = operations.QueryWith2Attr(username, count);
                command.Connection = connection;
                command.CommandText = queryString;

                return executeQuery(connection, command, "edited");              
            }
        }

        [HttpDelete]
        [Route("api/team/{username}")]
        public IHttpActionResult DeleteMember(string username)
        {
            string queryString = "DELETE FROM dbo.team WHERE username=@username";
            using (SqlConnection connection = createConnetion())
            {
                SqlCommand command = operations.QueryWithUsername(username);
                command.Connection = connection;
                command.CommandText = queryString;

                return executeQuery(connection, command, "deleted");
                
            }
        }

        
    }
}
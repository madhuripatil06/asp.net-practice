using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Data.SqlClient;
using Sql;
using System.Configuration;
using Queries;

namespace DatabaseSample.Controllers
{
    public class TeamController : ApiController
    {
        sqlQuery Operations =  new sqlQuery();
        SqlQueriesForTeam Queries = new SqlQueriesForTeam();
        private SqlConnection CreateConnetion()
        {
            var con = ConfigurationManager.ConnectionStrings["teamTable"].ConnectionString;
            return new SqlConnection(con);
        }

        private IHttpActionResult ExecuteQuery(SqlConnection connection, SqlCommand command, String message)
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
            using (SqlConnection connection = CreateConnetion())
            {
                SqlCommand command = new SqlCommand(Queries.GetSelectQuery(), connection);
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
            using (SqlConnection connection = CreateConnetion())
            {
                SqlCommand command = Operations.QueryWithUsernameAndCount(username, count);
                command.Connection = connection;
                command.CommandText = Queries.InsertUserQuery();
                return ExecuteQuery(connection, command, "inserted");
            }
        }


        [HttpPut]
        [Route("api/team/{username}/{count}")]
        public IHttpActionResult EditMember(string username, int count)
        {
            using (SqlConnection connection = CreateConnetion())
            {
                SqlCommand command = Operations.QueryWithUsernameAndCount(username, count);
                command.Connection = connection;
                command.CommandText = Queries.UpdateUserQuery();

                return ExecuteQuery(connection, command, "edited");              
            }
        }

        [HttpDelete]
        [Route("api/team/{username}")]
        public IHttpActionResult DeleteMember(string username)
        {
            using (SqlConnection connection = CreateConnetion())
            {
                SqlCommand command = Operations.QueryWithUsername(username);
                command.Connection = connection;
                command.CommandText = Queries.DeleteUserQuery();

                return ExecuteQuery(connection, command, "deleted");
                
            }
        }

        
    }
}
using System.Data;
using System.Data.SqlClient;

namespace Sql
{
    public class sqlQuery
    {
        public SqlCommand QueryWithUsernameAndCount(string username, int count)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter parameterUsername = new SqlParameter("@username", SqlDbType.VarChar);
            parameterUsername.Value = username;
            SqlParameter parameterCount = new SqlParameter("@count", SqlDbType.Int);
            parameterCount.Value = count;
            command.Parameters.Add(parameterCount);
            command.Parameters.Add(parameterUsername);
            return command;
        }


        public SqlCommand QueryWithUsername(string username)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter parameterUsername = new SqlParameter("@username", SqlDbType.VarChar);
            parameterUsername.Value = username;
            command.Parameters.Add(parameterUsername);
            return command;
        }

    }
}

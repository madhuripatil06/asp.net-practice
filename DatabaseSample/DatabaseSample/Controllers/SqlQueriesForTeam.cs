using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Queries
{
    public class SqlQueriesForTeam
    {
        public string GetSelectQuery()
        {
            return "SELECT username, count FROM dbo.team;";
        }

        public string InsertUserQuery()
        {
            return "INSERT INTO dbo.team(username, count) VALUES(@username, @count);";
        }


        public string UpdateUserQuery()
        {
            return "UPDATE dbo.team SET count= @count WHERE username=@username";
        }

        public string DeleteUserQuery()
        {
            return "DELETE FROM dbo.team WHERE username=@username";
        }


    }
}

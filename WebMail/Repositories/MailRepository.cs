using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebMail.Models.Entities;
using WebMail.Repositories.Interfaces;

namespace WebMail.Repositories
{
    public class MailRepository : IMailRepository
    {
        private readonly IDbConnection _dbConnection;

        public MailRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Mail> Get()
        {
            string sql = "SELECT * FROM mails";

            return _dbConnection.Query<Mail>(sql);
        }

        public void Create(Mail mail)
        {
            string sql = "INSERT INTO mails (\"date\", \"body\", \"result\", \"failedmessage\", \"destination\")" +
                $"values ({mail.Date}, {mail.Body}, {mail.Result}, {mail.FailedMessage}, {mail.Destination}) RETURNING id";

            mail.Id = _dbConnection.QuerySingle<int>(sql);
        }
    }
}

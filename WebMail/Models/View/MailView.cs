using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMail.Models.Entities;

namespace WebMail.Models.View
{
    public class MailView
    {
        public MailView(Mail mail)
        {
            Id = mail.Id;
            Date = mail.Date.ToString();
            Body = JsonConvert.DeserializeObject<BodyView>(mail.Body);
            Result = mail.Result;
            Destination = mail.Destination;
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата отправки в читаемом формате
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Содержимое письма (тема, тело, получатели)
        /// </summary>
        public BodyView Body { get; set; }
        /// <summary>
        /// Результат отправки сообщения
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// От кого было отправлено письмо
        /// </summary>
        public string Destination { get; set; }
    }
}

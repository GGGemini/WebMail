using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebMail.Models.View;

namespace WebMail.Models.Entities
{
    public class Mail
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Содержимое письма в формате JSON
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Результат отправки сообщения
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Текст ошибки при неудачной отправке сообщения
        /// </summary>
        public string FailedMessage { get; set; }
        /// <summary>
        /// С какой почты было отправлено сообщение
        /// </summary>
        public string Destination { get; set; }
    }
}

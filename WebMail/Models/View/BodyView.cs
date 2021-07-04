using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMail.Models.View
{
    public class BodyView
    {
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Тело письма
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Получатели
        /// </summary>
        public string[] Recipients { get; set; }
    }
}

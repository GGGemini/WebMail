using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMail.Settings
{
    public class MailSettings
    {
        /// <summary>
        /// С какой почты отправляем
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// Отображаемое адресату имя пользователя
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// SMTP-хост
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// SMTP-порт
        /// </summary>
        public int Port { get; set; }
    }
}

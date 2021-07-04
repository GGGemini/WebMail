using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMail.Models.DTO;
using WebMail.Models.View;

namespace WebMail.Services.Interfaces
{
    public interface IMailService
    {
        /// <summary>
        /// Получить все письма
        /// </summary>
        /// <returns></returns>
        IEnumerable<MailView> GetMails();
        /// <summary>
        /// Отправить письмо и здесь запись об этом в БД
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        Task<MailView> SendEmailAsync(SendMailDTO mailRequest);
    }
}

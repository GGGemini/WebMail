using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMail.Models.Entities;

namespace WebMail.Repositories.Interfaces
{
    public interface IMailRepository
    {
        /// <summary>
        /// Получение всех писем из БД
        /// </summary>
        /// <returns></returns>
        IEnumerable<Mail> Get();
        /// <summary>
        /// Создание записи о новом письме в БД
        /// </summary>
        /// <param name="mail"></param>
        void Create(Mail mail);
    }
}

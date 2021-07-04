using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMail.Models.DTO;
using WebMail.Models.Entities;
using WebMail.Models.View;
using WebMail.Repositories.Interfaces;
using WebMail.Services.Interfaces;
using WebMail.Settings;

namespace WebMail.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IMailRepository _mailRepository;

        public MailService(IOptions<MailSettings> mailSettings,
            IMailRepository mailRepository)
        {
            _mailSettings = mailSettings.Value;
            _mailRepository = mailRepository;
        }

        public IEnumerable<MailView> GetMails()
        {
            IEnumerable<Mail> mails = _mailRepository.Get();

            return mails.Select(m => new MailView(m));
        }

        public async Task<MailView> SendEmailAsync(SendMailDTO mailRequest)
        {
            // формируем email
            MimeMessage email = new MimeMessage
            {
                Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail),
                Subject = mailRequest.Subject,
            };

            // добавляем в сообщение получателей
            foreach (string recipient in mailRequest.Recipients)
            {
                email.To.Add(MailboxAddress.Parse(recipient));
            }

            // добавляем содержимое письма
            BodyBuilder builder = new BodyBuilder
            {
                HtmlBody = mailRequest.Body
            };
            email.Body = builder.ToMessageBody();

            var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);

            // готовим модель для записи в БД
            Mail mail = new Mail
            {
                Date = email.Date.LocalDateTime,
                Body = JsonConvert.SerializeObject(mailRequest),
                Destination = email.Sender.Address
            };

            try
            {
                await smtp.SendAsync(email);

                mail.Result = "Успешно";
            }
            catch (Exception ex)
            {
                mail.Result = "Ошибка";
                mail.FailedMessage = ex.Message;
            }
            smtp.Disconnect(true);

            _mailRepository.Create(mail);

            return new MailView(mail);
        }
    }
}

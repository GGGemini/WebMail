using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMail.Models.DTO;
using WebMail.Models.View;
using WebMail.Services.Interfaces;

namespace WebMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpGet]
        public IActionResult GetMails()
        {
            try
            {
                IEnumerable<MailView> result = _mailService.GetMails();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(SendMailDTO mailRequest)
        {
            try
            {
                MailView result = await _mailService.SendEmailAsync(mailRequest);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

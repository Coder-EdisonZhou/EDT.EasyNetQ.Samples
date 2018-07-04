using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Manulife.DNC.MSAD.Common;
using Manulife.DNC.MSAD.NB.NoticeService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Manulife.DNC.MSAD.NB.NoticeService.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost("/notice")]
        public IActionResult Notice()
        {
            var bytes = new byte[10240];
            var i = Request.Body.ReadAsync(bytes, 0, bytes.Length);
            var content = System.Text.Encoding.UTF8.GetString(bytes).Trim('\0');
            EmailSettings settings = new EmailSettings()
            {
                SmtpServer = Configuration["Email:SmtpServer"],
                SmtpPort = Convert.ToInt32(Configuration["Email:SmtpPort"]),
                AuthAccount = Configuration["Email:AuthAccount"],
                AuthPassword = Configuration["Email:AuthPassword"],
                ToWho = Configuration["Email:ToWho"],
                ToAccount = Configuration["Email:ToAccount"],
                FromWho = Configuration["Email:FromWho"],
                FromAccount = Configuration["Email:FromAccount"],
                Subject = Configuration["Email:Subject"]
            };

            EmailHelper.SendHealthEmailAsync(settings, content);

            return Ok();
        }
    }
}

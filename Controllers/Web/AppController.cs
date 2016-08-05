using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;
using TheWorld.Services;
using Microsoft.Extensions.Configuration;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        public AppController(IMailService mailService, IConfigurationRoot config){
            _mailService = mailService;
            _config = config;
        }
        public IActionResult Index(){
            return View();
        }
        public IActionResult Contact(){
            return View();
        }
        [HttpPost]
        public IActionResult  Contact(ContactViewModel model){
            if(ModelState.IsValid){
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From TheWorld", model.Message);
            }
            return View();
        }
        public IActionResult About(){
            return View();
        }
    }
}
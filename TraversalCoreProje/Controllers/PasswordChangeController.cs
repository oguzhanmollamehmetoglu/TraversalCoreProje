﻿using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(AppUserForGetPasswordDTO forGetPasswordViewModel)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(forGetPasswordViewModel.email);
                string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
                {
                    userId = user.Id,
                    token = passwordResetToken
                }, HttpContext.Request.Scheme);

                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "traversalseyahatturizim@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", forGetPasswordViewModel.email);
                mimeMessage.To.Add(mailboxAddressTo);
                var bodybuilder = new BodyBuilder();
                bodybuilder.TextBody = passwordResetTokenLink;
                mimeMessage.Body = bodybuilder.ToMessageBody();
                mimeMessage.Subject = "Şifre Değişiklik Talebi";
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("traversalseyahatturizim@gmail.com", "qguavhgmewqlbwrq");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
                return RedirectToAction("Index", "Default");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(AppUserResetPasswordDTO resetPasswordViewModel)
        {
            try
            {
                var userid = TempData["userid"];
                var token = TempData["token"];
                if (userid == null || token == null)
                {
                    //hata mesajı
                }
                var user = await _userManager.FindByIdAsync(userid.ToString());
                var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Singin", "Login");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
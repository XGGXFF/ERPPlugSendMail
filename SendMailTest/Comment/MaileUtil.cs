using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SendMailTest.Comment
{
    public class MaileUtil
    {
        public static void SendMail(string mailAddress, string mailTitle, string mailContent)
        {
            MailMessage objMailMessage = new MailMessage();
            string fromAddress = "3322600149@qq.com";//你在web.config中配置的发件人地址，就是你的邮箱地址。
            string mailHost = "smtp.qq.com";//邮件服务器，如mail.qq.com
            objMailMessage.From = new MailAddress(fromAddress);//发送方地址
            objMailMessage.To.Add(new MailAddress(mailAddress));//收信人地址
            objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;//邮件编码
            objMailMessage.Subject = mailTitle;//邮件标题
            objMailMessage.Body = mailContent;//邮件内容
            objMailMessage.IsBodyHtml = true;//邮件正文是否为html格式
            SmtpClient objSmtpClient = new SmtpClient();
            objSmtpClient.Host = mailHost;//邮件服务器地址 
            objSmtpClient.EnableSsl = true;
            objSmtpClient.UseDefaultCredentials = false;
            objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//通过网络发送到stmp邮件服务器
            NetworkCredential user = new NetworkCredential();
            user.UserName = "3322600149@qq.com";
            user.Password = "ecgpuwltlkficihf";
            objSmtpClient.Credentials = user;//发送方的邮件地址，密码
                                             //objSmtpClient.EnableSsl = true;//SMTP 服务器要求安全连接需要设置此属性
            try
            {
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
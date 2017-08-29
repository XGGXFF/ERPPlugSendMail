using SendMailTest.Bll;
using SendMailTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SendMailTest
{
    public partial class EditTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void SaveTemplate(string fileName, string fileContent)
        {
            TemplateBiz template = new TemplateBiz();
            template.SaveTemplate(fileName, fileContent);
        }

        [WebMethod]
        public static string LoadTemplate(int templeId)
        {
            var result = string.Empty;
            TemplateBiz template = new TemplateBiz();
            result = template.LoadTemplate(templeId);
            return result;
        }

        [WebMethod]
        public static void SendMail(string fileContent)
        {
            string touser = "714907920@qq.com";
            string title = "邮件推送测试";
            fileContent = fileContent.Replace("&quot;", "\"");
            MaileBiz.SendMail(touser, title, fileContent);
        }

        [WebMethod]
        public static List<Template> GetAllTemplate()
        {
            TemplateBiz template = new TemplateBiz();
            return template.GetAllTemplate();
        }
    }
}
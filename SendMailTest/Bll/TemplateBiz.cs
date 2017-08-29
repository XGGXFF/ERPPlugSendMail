using SendMailTest.Dal;
using SendMailTest.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SendMailTest.Bll
{
    public class TemplateBiz
    {
        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="templateContent"></param>
        /// <returns></returns>
        public bool SaveTemplate(string templateName, string templateContent)
        {
            string templateFileName = this.GetTemplatePath(templateName);
            using (FileStream fs = new FileStream(templateFileName, FileMode.Create))
            {
                StreamWriter streamWrite = new StreamWriter(fs);
                streamWrite.WriteLine(templateContent);
                streamWrite.Flush();
                streamWrite.Close();
                fs.Close();
            }

            return true;
        }
        
        public List<Template> GetAllTemplate()
        {
            return new TemplateDal().GetAllTemplate();
        }

        public string LoadTemplate(int id)
        {
            string result = string.Empty;
            string templateName = this.GetTemplateNameByID(id);
            string templateFileName = this.GetTemplatePath(templateName);

            using (FileStream fs = new FileStream(templateFileName, FileMode.OpenOrCreate))
            {
                StreamReader streamRead = new StreamReader(fs);
                result = streamRead.ReadToEnd();
                streamRead.Close();
                fs.Close();
            }

            return result=result.Replace("&quot;", "\"");
        }

        private string GetTemplateNameByID(int id)
        {
            string result = string.Empty;
            switch (id)
            {
                case 1:
                    result = "templateOne.html";
                    break;
                case 2:
                    result = "templateTwo.html";
                    break;
            }

            return result;
        }

        private string GetTemplatePath(string templateName)
        {
            string templatePath = string.Format("{0}EmailTemplate", AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            if (!Directory.Exists(templatePath))
            {
                DirectoryInfo dir = Directory.CreateDirectory(templatePath);
            }

            string templateFileName = string.Format("{0}\\{1}", templatePath, templateName);

            return templateFileName;
        }
    }
}
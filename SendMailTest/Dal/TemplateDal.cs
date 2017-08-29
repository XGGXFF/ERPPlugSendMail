using SendMailTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendMailTest.Dal
{
    public class TemplateDal
    {
        public List<Template> GetAllTemplate()
        {
            return new List<Template>
            {
                new Template { templateID = 1, templateName = "模板1" },
                new Template { templateID = 2, templateName = "模板2" }
            };
        }
    }
}
﻿using SendMailTest.Comment;
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
            Template template = new Template();
            template.SaveTemplate(fileName, fileContent);
        }

        [WebMethod]
        public static string LoadTemplate(int templeId)
        {
            var result = string.Empty;
            Template template = new Template();
            result= template.LoadTemplate(templeId);
            return result;
        }
    }
}
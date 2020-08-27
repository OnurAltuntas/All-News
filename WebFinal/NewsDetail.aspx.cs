using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        public string temp;
        public string temp2;

        ArrayList AllNews = new ArrayList();
        public News objTemp;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            string id = (Request.QueryString["id"]).ToString();
            temp = id;
            temp2 = temp.Replace("<","");
            temp2 = temp2.Replace(">", "");
            AllNews = Session["AllNews"] as ArrayList;

            logger.Info("Haber başarıyla getirildi");


            foreach (var item in AllNews)
            {
                if((item as News).Title == temp2)
                {
                    logger.Info("Haber Detayları belirlendi başarıyla yazdırıldı.");
                    objTemp = item as News;
                }
                Response.Write((item as News).Title);
            }

           //Response.Write((objTemp.Title));

            temp = id;
            //if((Session["selectedNews"] != null)){
            //    Response.Write((Session["selectedNews"] as News).Title);
            //}
            Response.Write(id.ToString());
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class Home : System.Web.UI.Page
    {
        public ArrayList NewsAll = new ArrayList();
        public ArrayList OriginalNewsAll = new ArrayList();
        public ArrayList Egitim = new ArrayList();
        public ArrayList DisHaberler = new ArrayList();
        public ArrayList Ekonomi = new ArrayList();
        public ArrayList Gundem = new ArrayList();
        public ArrayList Siyaset = new ArrayList();
        public ArrayList Spor = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList allNews = Session["MyArrayList"] as ArrayList;
            OriginalNewsAll = allNews;
            NewsAll = allNews;
            if (allNews != null)
            {
                foreach (var item in NewsAll)
                {
                    //Response.Write((item as News).ImageUrl);
                }
            }
            Session["AllNews"] = NewsAll;
        }
        protected void btnDisHaberler_Click(object sender, EventArgs e)
        {
            NewsAll = OriginalNewsAll;

            foreach (var item in NewsAll)
            {
                if ((item as News).Category == "Dış Haberler")
                {
                    DisHaberler.Add(item);
                }
            }
            NewsAll = DisHaberler;
            foreach (var item in DisHaberler)
            {
                // Response.Write((item as News).ImageUrl);
            }
        }
        protected void btnEkonomi_Click(object sender, EventArgs e)
        {
            NewsAll = OriginalNewsAll;
            foreach (var item in NewsAll)
            {
                if ((item as News).Category == "Ekonomi")
                {
                    Ekonomi.Add(item);
                }
            }
            NewsAll = Ekonomi;
            foreach (var item in Ekonomi)
            {
                //Response.Write((item as News).ImageUrl);
            }
        }

        protected void btnGundem_Click(object sender, EventArgs e)
        {
            NewsAll = OriginalNewsAll;
            foreach (var item in NewsAll)
            {
                if ((item as News).Category == "Gündem")
                {
                    Gundem.Add(item);
                }
            }
            NewsAll = Gundem;
            foreach (var item in Gundem)
            {
                //Response.Write((item as News).ImageUrl);
            }
        }
        protected void btnSiyaset_Click(object sender, EventArgs e)
        {
            NewsAll = OriginalNewsAll;
            foreach (var item in NewsAll)
            {
                if ((item as News).Category == "Siyaset")
                {
                    Siyaset.Add(item);
                }
            }
            NewsAll = Siyaset;
            foreach (var item in Siyaset)
            {
                //Response.Write((item as News).ImageUrl);
            }
        }
        protected void btnSpor_Click(object sender, EventArgs e)
        {
            NewsAll = OriginalNewsAll;
            foreach (var item in NewsAll)
            {
                if ((item as News).Category == "Spor")
                {
                    Spor.Add(item);
                }
            }
            NewsAll = Spor;
            foreach (var item in Spor)
            {
                //Response.Write((item as News).ImageUrl);
            }
        }
        protected void btnEgitim_Click(object sender, EventArgs e)
        {
            NewsAll = OriginalNewsAll;
            foreach (var item in NewsAll)
            {
                if((item as News).Category== "Eğitim")
                {
                    Egitim.Add(item);
                }
            }
            
            NewsAll = Egitim;
            foreach (var item in Egitim)
            {
                //Response.Write((item as News).ImageUrl);
            }
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            //Response.Redirect("NewsDetail.aspx");
        }


    }
}
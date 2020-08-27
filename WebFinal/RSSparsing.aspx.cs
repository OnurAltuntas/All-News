using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace WebFinal
{
    public partial class RSSparsing : System.Web.UI.Page
    {
        int newsIdCounter = 0;
        ArrayList readedNews = new ArrayList();
        public ArrayList clients = new ArrayList();
        public ArrayList imgUrls = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            PopulateRssFeed();

            string formattedDate = DateTime.Now.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("en-US"));
            Response.Write(formattedDate);

            string databaseStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("App_Data/Allnews.mdb");
            OleDbConnection con = new OleDbConnection(databaseStr);
            con.Open();
            Response.Write("Database is connected!");

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Allnews", con);
            OleDbDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                string phrase = (dataReader["PubDate"].ToString());
                string[] words = phrase.Split(' ');
                ArrayList tempSplit = new ArrayList();
                foreach (var word in words)
                {
                    tempSplit.Add(word);

                }
                string myDate = "";
                myDate += tempSplit[1].ToString() + " " + tempSplit[2].ToString() + " " + tempSplit[3].ToString();
                Response.Write(myDate + "<br/>");

                if (myDate == "19 Jun 2020")
                {
                    News f = new News(Convert.ToInt32(dataReader["Id"]), (dataReader["Title"].ToString()), (dataReader["Description"].ToString()), (dataReader["Category"].ToString()), (dataReader["PubDate"].ToString()), (dataReader["Author"].ToString()), (dataReader["ImageUrl"].ToString()));
                    readedNews.Add(f);
                    imgUrls.Add(f.ImageUrl);
                }
                else
                {
                    Response.Write("degil" + "<br/>");
                }
            }
            con.Close();
            Session["MyArrayList"] = readedNews;

            Response.Redirect("Home.aspx");

        }

        private void PopulateRssFeed()
        {
            const string dishaberler = "https://ajanda.dha.com.tr/feed/rss/dis-haberler/";
            const string egitim = "https://ajanda.dha.com.tr/feed/rss/egitim/";
            const string ekonomi = "https://ajanda.dha.com.tr/feed/rss/ekonomi/";
            const string gundem = "https://ajanda.dha.com.tr/feed/rss/gundem/";
            const string siyaset = "https://ajanda.dha.com.tr/feed/rss/siyaset/";
            const string spor = "https://ajanda.dha.com.tr/feed/rss/spor//";

            ArrayList categoriesUrls = new ArrayList();

            categoriesUrls.Add(dishaberler);
            categoriesUrls.Add(egitim);
            categoriesUrls.Add(ekonomi);
            categoriesUrls.Add(gundem);
            categoriesUrls.Add(siyaset);
            categoriesUrls.Add(spor);

            List<News> feeds = new List<News>();
            ArrayList arrTemp = new ArrayList();
            try
            {
                foreach (var urlitem in categoriesUrls)
                {
                    XDocument xDoc = new XDocument();
                    xDoc = XDocument.Load(urlitem.ToString());
                    var items = (from x in xDoc.Descendants("item")
                                 select new
                                 {
                                     newsId = newsIdCounter++,
                                     title = x.Element("title").Value,
                                     pubDate = x.Element("pubDate").Value,
                                     description = x.Element("description").Value,
                                     category = x.Element("category").Value,
                                     author = x.Element("author").Value,
                                     Image = x.Element("title").Value,
                                     //image cekemedim

                                 });

                    var Images = (from b in xDoc.Descendants("enclosure")
                                  select new
                                  {
                                      ImagesUrl = b.Attribute("url").Value
                                  });


                    if (items != null)
                    {
                        int counter = 0;
                        foreach (var i in items)
                        {

                            foreach (var item in Images)
                            {
                                arrTemp.Add(item.ImagesUrl);
                            }
                            News f = new News(i.newsId, i.title, i.description, i.category, i.author, i.pubDate, arrTemp[counter].ToString());
                            
                            counter++;
                            feeds.Add(f);


                            //string databaseStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("App_Data/Allnews.mdb");
                            //OleDbConnection data = new OleDbConnection(databaseStr);
                            //data.Open();
                            //OleDbCommand cmd = new OleDbCommand("INSERT INTO Allnews(Id,Description,Author,PubDate,Category,ImageUrl,Title) VALUES(@Id,@Description,@Author,@PubDate,@Category,@ImageUrl,@Title)", data);
                            //cmd.Parameters.AddWithValue("Id", feeds[i.newsId].NewsID);
                            //cmd.Parameters.AddWithValue("Description", feeds[i.newsId].Description);
                            //cmd.Parameters.AddWithValue("Author", feeds[i.newsId].Author);
                            //cmd.Parameters.AddWithValue("PubDate", feeds[i.newsId].PubDate);
                            //cmd.Parameters.AddWithValue("Category", feeds[i.newsId].Category);
                            //cmd.Parameters.AddWithValue("ImageUrl", feeds[i.newsId].ImageUrl);
                            //cmd.Parameters.AddWithValue("Title", feeds[i.newsId].Title);

                            //Response.Write("veri tabanı bağlandı yazıldı");

                            //data.Close();

                            //try
                            //{
                            //    data.Open();
                            //    cmd.ExecuteNonQuery();
                            //    Response.Write("veri tabanı bağlandı yazıldı");
                            //    data.Close();
                            //}
                            //catch (Exception ex)
                            //{
                            //    Response.Write(ex.Message + " hata");
                            //}
                            //finally
                            //{
                            //    data.Close();
                            //}
                            //data.Close();


                        }
                    }

                    //gvRss.DataSource = feeds;
                    //gvRss.DataBind();

                    //Rgallary.DataSource = feeds;
                    //Rgallary.DataBind();
                    this.clients = readedNews;
                    

                }
               

               
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
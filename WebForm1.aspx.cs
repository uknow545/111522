using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            proc();
        }
        private void proc()
        {
           HtmlWeb webClient = new HtmlWeb();
           HtmlDocument linedoc = webClient.Load("https://twur.cpami.gov.tw/zh/merchant/announcement/0");  //載入網址資料                                                                                           // HtmlDocument linedoc = webClient.Load("https://www.google.com/search?q=都更&start=1");  
           HtmlNodeCollection linelist = linedoc.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[1]/div[5]/table[1]//a"); //抓取Xpath資料
           List<string> lsUrl = new List<string>();
           List<string> lsUrldtl = new List<string>();

           foreach (var item in linelist)
           {
               // if (IsNumeric(item.InnerText))                      
               if (item.Attributes["title"] != null)
               {
                   lsUrl.Add(item.Attributes["href"].Value + ";" + item.Attributes["title"].Value);
                   linedoc = webClient.Load(item.Attributes["href"].Value);  //載入網址資料
                   lsUrldtl.Add(linedoc.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[1]").FirstOrDefault().OuterHtml); //抓取Xpath資料

               }

           }
           gv1.DataSource = lsUrldtl;
           gv1.DataBind();
        }

    }
    }
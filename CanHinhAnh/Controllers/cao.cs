using CanHinhAnh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CanHinhAnh.Controllers
{
    public class cao
    {
        public List<img> list = new List<img>();
        mahoa mh = new mahoa();

      

        string tach(string s)
        {
            var CourseList1 = Regex.Matches(s, @"src=""(.*?)""", RegexOptions.Singleline);
           // var CourseList1 = Regex.Matches(s, @"""(.*?)""", RegexOptions.Singleline);
            string s1 = CourseList1[0].ToString();
            s1 = s1.Replace("src=","");
            s1 = s1.Replace('"',' ');
            s1 = s1.Trim();
            if (s1.IndexOf("https:") == -1)
            {
                s1 = "https:" + s1;
            }

            s1 = mh.giaima(s1);
            return s1;
        }
        public List<img> Crawl(string html)
        {
            //List<string> l = new List<string>();
            //string htmlLearn = CrawlDataFromURL(url);
            //     var CourseList = Regex.Matches(html, @"<img data-src=""(.*?)""", RegexOptions.Singleline);
            var CourseList = Regex.Matches(html, @"<img(.*?)>", RegexOptions.Singleline);


            foreach (var course in CourseList)
            {
                img i = new img();
                i.link = tach(course.ToString());
                i.size = tinhdungluongimg(i.link);

                list.Add(i);
              
            }

            list.Sort(delegate (img x, img y) {
                return y.size.CompareTo(x.size);
            });

    
            return list;
        }
        public double tinhdungluongimg(string url)
        {
            try
            {
            using (WebClient webClient = new WebClient())
            {
                    //  FileInfo fi = new FileInfo("https://cdn.tgdd.vn//content/Untitled-1-150x150-4.png");
                    //cdn.tgdd.vn/2022/05/banner/hugi12-1200x200.png


                      byte[] data1 = webClient.DownloadData(url);
                   // byte[] data1 = webClient.DownloadData("https://cdn.tgdd.vn/2022/05/banner/pamper12-1200x200.png");
                    return data1.Length / 1024.0;
               
            }
            }
            catch(Exception e)
            {
 return 0;
            }
            
           
        }
    }
}

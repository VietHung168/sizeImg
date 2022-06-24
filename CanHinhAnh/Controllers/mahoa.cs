using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CanHinhAnh.Controllers
{
    public class UniHex
    {
        public string uni { get; set; }
        public string hex { get; set; }
        public UniHex(string u, string h)
        {
            this.uni = u;
            this.hex = h;
        }
    }
    public class mahoa
    {
        List<UniHex> listgiaima = new List<UniHex>();
        public mahoa()
        {
            docfilemahoa();
        }
        public string[] docfilemahoa()
        {
            string[] a = File.ReadAllLines("df.txt");
            for (int i = 0; i < a.Length; i++)
            {
                string[] arrListStr = a[i].Split('\t');
                if(arrListStr.Length>2)
                listgiaima.Add(new UniHex(arrListStr[0], arrListStr[arrListStr.Length - 2]));

            }
            a.ToArray();
            return a;
        }
        public string giaima(string link)
        {
            string ss = "https://cdn.tgdd.vn//content/Iconma&#x301;ytie&#x323;&#x302;ttru&#x300;ng-150x150.png";
            foreach (UniHex d in listgiaima)
            {

                link = link.Replace(d.hex,d.uni);
            }
            return link;
        } 
    }
}

 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebApp.Models
{
    public class MenuProvider
    {
        static XmlNode GetRoot()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("/menu.xml"));
            string controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            XmlNode node = doc.SelectSingleNode(string.Format("//menu[@id='{0}']", controller));
            return node;
        }
        static Item GetItem(XmlNode item)
        {
            return new Item { Value = item.Attributes["value"].Value, Url = item.Attributes["url"].Value };
        }
        public static List<Item> GetMenu()
        {
            XmlNode node = GetRoot();
            List<Item> list = new List<Item>();
            foreach (XmlNode item in node.ChildNodes)
            {
                Item i = GetItem(item);
                list.Add(i);
                if (item.HasChildNodes)
                {
                    i.Items = new List<Item>();
                    foreach (XmlNode child in item.ChildNodes)
                    {
                        i.Items.Add(GetItem(child));
                    }
                }
            }
            return list;
        }
        public static string GetModule()
        {
            XmlNode node = GetRoot();
            return node.Attributes["module"].Value;
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using Bai11_Blog.Models;

namespace Bai11_Blog.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return View(GetPosts_Result());
        }

        public ActionResult Detail(int id)
        {
            Post p = Search_Post(id);
            p.Content = Get_Content(p.File);

            return View(p);
        }

        private List<Post> GetPosts_Result()
        {
            List<Post> posts = XML_to_Post();
            List<Post> posts_result = new List<Post>();

            foreach (Post p in posts)
            {
                p.Content = Get_Content(p.File);

                posts_result.Add(p);
            }

            return posts_result;
        }

        private List<string> Get_Content(string fileName)
        {
            string file_path = Server.MapPath("~/txt/" + fileName);
            string[] info = System.IO.File.ReadAllLines(file_path);

            return info.ToList();
        }

        private List<Post> XML_to_Post()
        {
            List<Post> posts = new List<Post>();

            string path_fXML = Server.MapPath("~/xml/Posts.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path_fXML);

            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                Post p = new Post();
                p.PostID = int.Parse(node.Attributes[0].InnerText);

                foreach (XmlNode child in node.ChildNodes)
                {
                    switch (child.Name)
                    {
                        case "name":
                            p.Name = child.InnerText;
                            break;
                        case "category":
                            p.Category = child.InnerText;
                            break;
                        case "file":
                            p.File = child.InnerText;
                            break;
                    };
                }

                posts.Add(p);
            }

            return posts;
        }

        private Post Search_Post(int id)
        {
            Post p = new Post();

            string path_fXML = Server.MapPath("~/xml/Posts.xml");
            XDocument xDocument = XDocument.Load(path_fXML);

            var xElement = xDocument.Element("posts").Elements("post").Where(element => element.Attribute("id").Value == id.ToString()).FirstOrDefault();

            if (xElement != null)
            {
                p.PostID = int.Parse(xElement.Attribute("id").Value);
                p.Name = xElement.Element("name").Value;
                p.Category = xElement.Element("category").Value;
                p.File = xElement.Element("file").Value;
            }

            return p;
        }
    }
}
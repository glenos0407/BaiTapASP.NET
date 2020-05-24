using Bai10_QLSanPham.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Bai10_QLSanPham.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View(XML_to_Product());
        }

        public ActionResult Detail(int id)
        {
            return View(Search_Product(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p, HttpPostedFileBase imageUpload)
        {
            if(imageUpload != null)
            {
                string path_img = Server.MapPath("~/Imgs/" + imageUpload.FileName);
                imageUpload.SaveAs(path_img);

                p.Image = imageUpload.FileName;
            }

            if (!Create_Product(p))
            {
                ViewBag.Message = "ID Tồn Tại !";
                return View();
            }

            return RedirectToAction("Index", "Product", XML_to_Product());
        }

        public ActionResult Edit(int id)
        {
            return View(Search_Product(id));
        }

        [HttpPost]
        public ActionResult Edit(Product p, HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null)
            {
                string path_img = Server.MapPath("~/Imgs/" + imageUpload.FileName);
                imageUpload.SaveAs(path_img);

                p.Image = imageUpload.FileName;
            }

            Edit_Product(p);

            return RedirectToAction("Index", "Product", XML_to_Product());
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Delete_Product(id);
            return RedirectToAction("Index", "Product", XML_to_Product());
        }

        private List<Product> XML_to_Product()
        {
            List<Product> products = new List<Product>();

            string path_fXML = Server.MapPath("~/XML/Products.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path_fXML);

            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                Product p = new Product();
                p.ProductID = int.Parse(node.Attributes[0].InnerText);

                foreach (XmlNode child in node.ChildNodes)
                {
                    switch (child.Name)
                    {
                        case "Name":
                            p.Name = child.InnerText;
                            break;
                        case "Price":
                            p.Price = double.Parse(child.InnerText);
                            break;
                        case "Image":
                            p.Image = child.InnerText;
                            break;
                    };
                }

                products.Add(p);
            }

            return products;
        }

        private Product Search_Product(int id)
        {
            string path_fXML = Server.MapPath("~/XML/Products.xml");
            XDocument xDocument = XDocument.Load(path_fXML);

            var xElement = xDocument.Element("products").Elements("product").Where(element => element.Attribute("id").Value == id.ToString()).FirstOrDefault();

            Product p = new Product();

            if (xElement != null)
            {
                p.ProductID = int.Parse(xElement.Attribute("id").Value);
                p.Name = xElement.Element("Name").Value;
                p.Price = Convert.ToDouble(xElement.Element("Price").Value);
                p.Image = xElement.Element("Image").Value;
            }

            return p;
        }

        private Boolean Create_Product(Product product)
        {
            string path_fXML = Server.MapPath("~/XML/Products.xml");
            XDocument xDocument = XDocument.Load(path_fXML);
            var xElement = xDocument.Element("products").Elements("product").Where(element => element.Attribute("id").Value == product.ProductID.ToString()).FirstOrDefault();

            if (xElement != null)
            {
                return false;
            }

            XAttribute idAttribute = new XAttribute("id", product.ProductID.ToString());
            XElement NameElement = new XElement("Name", product.Name);
            XElement priceElement = new XElement("Price", product.Price.ToString());
            XElement imageElement = new XElement("Image", product.Image);

            xDocument.Element("products").Add(new XElement("product", idAttribute, NameElement, priceElement, imageElement));

            xDocument.Save(path_fXML);

            return true;
        }

        private void Edit_Product(Product product)
        {
            string path_fXML = Server.MapPath("~/XML/Products.xml");
            XDocument xDocument = XDocument.Load(path_fXML);
            var xElement = xDocument.Element("products").Elements("product").Where(element => element.Attribute("id").Value.Equals(product.ProductID.ToString())).FirstOrDefault();

            if (xElement != null)
            {
                xElement.SetAttributeValue("id", product.ProductID.ToString());
                
                if (!product.Name.Trim().Equals(""))
                {
                    xElement.SetElementValue("Name", product.Name);
                }

                xElement.SetElementValue("Price", Convert.ToDouble(product.Price));

                if (!product.Image.Trim().Equals(""))
                {
                    xElement.SetElementValue("Image", product.Image);
                }
            }

            xDocument.Save(path_fXML);
        }

        private void Delete_Product(int id)
        {
            string path_fXMl = Server.MapPath("~/XML/Products.xml");

            //Doc File XML
            XDocument xDocument = XDocument.Load(path_fXMl);
            var xElement = xDocument.Element("products").Elements("product").Where(element => element.Attribute("id").Value.Equals(id.ToString())).FirstOrDefault();

            if (xElement != null)
            {
                xElement.Remove();
                xDocument.Save(path_fXMl);
            }
        }
    }
}
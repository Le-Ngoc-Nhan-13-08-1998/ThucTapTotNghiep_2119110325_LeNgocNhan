using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NNStore.Context;
using static NNStore.Common;

namespace NNStore.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        // GET: Admin/Product
        NNStoreEntities ojbNNStoreEntities = new NNStoreEntities();

        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<Product >();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;

            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstProduct = ojbNNStoreEntities.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = ojbNNStoreEntities.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index(string SearchString)
        //{
        //    var lstProduct = ojbWebsiteBanHangEntities.Product_2119110325.Where(n => n.Name.Contains(SearchString)).ToList();

        //    return View(lstProduct);
        //}
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }
        [ValidateInput(false)]
        
        public ActionResult Create(Product objproduct_2119110325)
        {
            this.LoadData();

            try
            {
                if (objproduct_2119110325.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objproduct_2119110325.ImageUpload.FileName);
                    string extention = Path.GetExtension(objproduct_2119110325.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                    objproduct_2119110325.Img = fileName;
                    objproduct_2119110325.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                }
                ojbNNStoreEntities.Products.Add(objproduct_2119110325);
                ojbNNStoreEntities.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return View();
            }

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var ojbProduct = ojbNNStoreEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(ojbProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ojbProduct = ojbNNStoreEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(ojbProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product  objPro)
        {
            var ojbProduct = ojbNNStoreEntities.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            ojbNNStoreEntities.Products.Remove(ojbProduct);
            ojbNNStoreEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            this.LoadData();
            var ojbProduct = ojbNNStoreEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            Session["anhgoc"] = ojbProduct.Img;
            return View(ojbProduct);
        }
        [ValidateInput(false)]
        [HttpPost]
        
        public ActionResult Edit(int id, Product objProduct)
        {
            this.LoadData();
           
            try
            {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extention = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + extention;
                    objProduct.Img = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                   
                }
                //else
                //{
                //    objProduct.Avatar = Session["anhgoc"].ToString();
                //}
                objProduct.UpdatedAt = DateTime.Now;
                ojbNNStoreEntities.Entry(objProduct).State = EntityState.Modified;
                ojbNNStoreEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        void LoadData()
        {

            Common objCommon = new Common();
            var lstCat = ojbNNStoreEntities.Categories.ToList();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            var lstBrand = ojbNNStoreEntities.Brands.ToList();

            DataTable dtBrand = converter.ToDataTable(lstBrand);
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");

            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá";
            lstProductType.Add(objProductType);
            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromotionEngineCartApp.Models
{
    public class SkuItemResultModel
    {
        public List<SkuItemModel> lstSkuItem { get; set; }
        public List<SkuItemModel> GetActualPrice()
        {
            return lstSkuItem = new List<SkuItemModel>() {
            new SkuItemModel() { Unit = "A", Price = 50 },
            new SkuItemModel() { Unit = "B", Price = 30 },
            new SkuItemModel() { Unit = "C", Price = 20 },new SkuItemModel() {  Unit = "D", Price = 15} };
        }
    }
}
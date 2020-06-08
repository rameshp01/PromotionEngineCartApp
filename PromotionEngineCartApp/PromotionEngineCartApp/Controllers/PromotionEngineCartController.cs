using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PromotionEngineCartApp.Models;
namespace PromotionEngineCartApp.Controllers
{
    public class PromotionEngineCartController : Controller
    {
        private SkuItemResultModel _skuProductModel = new SkuItemResultModel();
        List<SkuItemModel> _skuItemList;
        public ActionResult Index()
        {
            _skuItemList = _skuProductModel.GetActualPrice();
            return View(_skuItemList.ToList());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CreateOrder()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(SkuItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                SkuPromotionItemModel skuPromotionModel = model.PromotionItemVM;

                _skuItemList = new List<SkuItemModel>();
                int promotionType, TotalAmountA, TotalAmountB, TotalAmountC, TotalAmountD = 0;
                promotionType = (int)SkuType.activePromotion.A;
                TotalAmountA = TotalAmount(skuPromotionModel.UnitA, promotionType);
                _skuItemList.Add(new SkuItemModel() { Unit = skuPromotionModel.UnitA + "A", Price = TotalAmountA });
                promotionType = (int)SkuType.activePromotion.B;
                TotalAmountB = TotalAmount(skuPromotionModel.UnitB, promotionType);
                _skuItemList.Add(new SkuItemModel() { Unit = skuPromotionModel.UnitB + "B", Price = TotalAmountB });
                if (skuPromotionModel.UnitC > 0 && skuPromotionModel.UnitD == 0)
                {
                    promotionType = (int)SkuType.activePromotion.C;
                    TotalAmountC = TotalAmount(skuPromotionModel.UnitC, promotionType);
                    _skuItemList.Add(new SkuItemModel() { Unit = skuPromotionModel.UnitC + "C", Price = TotalAmountC });
                }
                if (skuPromotionModel.UnitC == 0)
                {
                    _skuItemList.Add(new SkuItemModel() { Unit = skuPromotionModel.UnitC + "C", Price = 0 });
                }
                if (skuPromotionModel.UnitC == 0 && skuPromotionModel.UnitD > 0)
                {
                    promotionType = (int)SkuType.activePromotion.D;
                    TotalAmountD = TotalAmount(skuPromotionModel.UnitD, promotionType);
                    _skuItemList.Add(new SkuItemModel() { Unit = skuPromotionModel.UnitD + "D", Price = TotalAmountD });
                }
                if (skuPromotionModel.UnitD == 0)
                {
                    _skuItemList.Add(new SkuItemModel() { Unit = skuPromotionModel.UnitD + "D", Price = 0 });
                }
                if (skuPromotionModel.UnitC > 0 && skuPromotionModel.UnitD > 0)
                {
                    promotionType = (int)SkuType.activePromotion.CD;
                    TotalAmountD = TotalAmount(skuPromotionModel.UnitD, promotionType);
                    _skuItemList.Add(new SkuItemModel() { Unit = skuPromotionModel.UnitC + "C and " + skuPromotionModel.UnitD + "D", Price = TotalAmountD });
                }

                SkuItemResultModel smodel = new SkuItemResultModel();
                model.ResultSetVM = new SkuItemResultModel();
                model.ResultSetVM.lstSkuItem = _skuItemList;
            }
            return View(model);
        }
        public int TotalAmount(int totalunit, int promotionType)
        {
            int totalAmount = 0;
            int promotionUnit = 0;
            int actualUnit = 0;
            switch (promotionType)
            {
                case 0:
                    if (totalunit >= 3)
                    {
                        promotionUnit = totalunit / 3;
                        actualUnit = totalunit % 3;
                        totalAmount = (promotionUnit * 130) + (actualUnit * 50);
                    }
                    else
                    {
                        totalAmount = totalunit * 50;
                    }
                    break;
                case 1:
                    if (totalunit >= 2)
                    {
                        promotionUnit = totalunit / 2;
                        actualUnit = totalunit % 2;
                        totalAmount = (promotionUnit * 45) + (actualUnit * 30);
                    }
                    else
                    {
                        totalAmount = totalunit * 30;
                    }
                    break;
                case 2:
                    totalAmount = totalunit * 20;
                    break;
                case 3:
                    totalAmount = totalunit * 15;
                    break;
                case 4:
                    totalAmount = totalunit * 30;
                    break;
                default:
                    break;
            }
            return totalAmount;
        }
    }
}
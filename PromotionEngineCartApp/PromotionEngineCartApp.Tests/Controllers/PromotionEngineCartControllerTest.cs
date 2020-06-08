using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngineCartApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineCartApp.Controllers;
namespace PromotionEngineCartApp.Tests.Controllers
{
    [TestClass()]
    public class PromotionEngineCartControllerTest
    {
        [TestMethod()]
        public void CreateOrderTest()
        {
            var objPromotionEngine = new PromotionEngineCartController();
            SkuItemViewModel objSkuItemViewModel = new SkuItemViewModel();
            SkuPromotionItemModel objPromotionModel = new SkuPromotionItemModel { UnitA = 4, UnitB = 3, UnitC = 2, UnitD = 5 };
            objSkuItemViewModel.PromotionItemVM = objPromotionModel;

            var Res = objPromotionEngine.CreateOrder(objSkuItemViewModel);

            Assert.IsNotNull(Res);
        }
    }
}

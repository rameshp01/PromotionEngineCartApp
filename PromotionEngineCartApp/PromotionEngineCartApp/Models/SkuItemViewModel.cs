using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromotionEngineCartApp.Models
{
    public class SkuItemViewModel
    {
        public SkuPromotionItemModel PromotionItemVM { get; set; }
        public SkuItemModel AccountVM { get; set; }
        public SkuItemResultModel ResultSetVM { get; set; }
    }
}
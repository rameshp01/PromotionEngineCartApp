using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
namespace PromotionEngineCartApp.Models
{
    public class SkuPromotionItemModel
    {
        [DisplayName("No. of Item for A")]

        [DefaultValue(0)]
        public int UnitA { get; set; }
        [DisplayName("No. of Item for B")]
        public int UnitB { get; set; }
        [DisplayName("No. of Item for C")]
        public int UnitC { get; set; }
        [DisplayName("No. of Item for D")]
        public int UnitD { get; set; }
    }
}
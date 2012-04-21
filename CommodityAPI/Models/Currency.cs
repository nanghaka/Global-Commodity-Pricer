using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CommodityAPI.Models
{
    public class Currency
    {
        [Key]
        public virtual int CurrencyID { get; set; }
        public virtual string CurrencyName { get; set; }

       
    }
}
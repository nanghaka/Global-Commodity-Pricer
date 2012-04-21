using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CommodityAPI.Models
{
   public  class Country
    {
       
       [Key]
        public virtual  int CountryID { get; set; }
       public virtual string CountryName { get; set; }

        public virtual int CurrencyID { get; set; }
        public virtual Currency Currencies { get; set; }


        public virtual ICollection<UserProfile> UserProfiles { get; set; }

    }
}

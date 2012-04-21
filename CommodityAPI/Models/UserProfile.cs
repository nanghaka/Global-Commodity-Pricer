using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CommodityAPI.Models
{
    public class UserProfile
    {
        [Key]
        public virtual int UserID { get; set; }
        public virtual string UserName { get; set; }
        public virtual  string Password { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string PhoneNumber { get; set; }


        public virtual int CountryID { get; set; }
        public virtual Country Countries { get; set; }
    }
}
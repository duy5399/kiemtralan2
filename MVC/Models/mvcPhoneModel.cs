using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcPhoneModel
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string GenaralNote { get; set; }
    }
}
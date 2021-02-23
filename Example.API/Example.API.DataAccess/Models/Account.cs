using System;
using System.Collections.Generic;
using System.Text;

namespace Example.API.DataAccess.Models
{
    public class Account
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public bool isParent { get; set; }
    }
}

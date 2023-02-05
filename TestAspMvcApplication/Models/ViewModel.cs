using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAspMvcApplication.DataAccess;

namespace TestAspMvcApplication.Models
{
    public class ViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public SelectList SelectList { get; set; }
        public string FilterListName { get; set; }
        public string RequestUrl { get; set; }
    }
}
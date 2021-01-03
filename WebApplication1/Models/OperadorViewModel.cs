using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class OperadorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> RolesIds { get; set; }

        [Display(Name = "Roles")]
        public MultiSelectList Roles { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    [Table("tb_m_department")]
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public Department()
        {

        }
    }
}
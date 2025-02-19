﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public int Code { get; set; }
        public DateTime? DateOfCreation { get; set; }
        [InverseProperty("Department")]
        public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();
    }
}

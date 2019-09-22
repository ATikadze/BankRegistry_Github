using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Bank
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string URL { get; set; }
        public virtual ICollection<ContactPerson> ContactPersons { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class ContactPerson
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public virtual Bank Bank { get; set; }
        [Required]
        public virtual int PositionID { get; set; }
        [Required]
        public virtual Position Position { get; set; }
    }
}

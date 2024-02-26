using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class DemoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int demoId { get; set; }
        [Required]
        public string demoName { get; set; }
        public string demoaddress { get; set; }
        public string demoCity { get; set; }
    }
}

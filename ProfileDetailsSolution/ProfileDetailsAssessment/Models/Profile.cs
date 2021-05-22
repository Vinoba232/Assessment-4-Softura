using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileDetailsAssessment.Models
{
    public class Profile
    {
        [Key]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
        public bool IsEmployed { get; set; }
        public string NoticePeriod { get; set; }
        public string CurrentCTC { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Models
{
    public class Input: BaseEntity
    {
        [Required]
        public string StudyName { get; set; }

        [Required]
        public DateTime StudyStartDate { get; set; }

       
        public DateTime EstimatedCompletionDate { get; set; }

       
        public string ProtocolID { get; set; }


        public string StudyGroup { get; set; }
        public string Phase { get; set; }
        public string PrimaryIndication { get; set; }
        public string SecondaryIndication { get; set; }
   
    }
}

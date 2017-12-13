using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FSpacerFinal.Models
{
    public class DriveCard
    {
        public string Model { get; set; }
        public string Ratio { get; set; }
        [Key]
        public string DriveNumber { get; set; }
        public string GearNumber { get; set; }

    }
}

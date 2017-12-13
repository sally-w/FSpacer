using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSpacerFinal.Models
{
    public class SpacerVM
    {
        public int ID { get; set; }
        public bool Active { get; set; }

        public int HorizontalGearCaseDeviation { get; set; }
        public int HorizontalCarrierDeviation { get; set; }
        public int Bearing { get; set; }
        public float HMDGear { get; set; }


        public int VerticalGearCaseDeviation { get; set; }
        public int VerticalCarrierDeviation { get; set; }
        public float GearMount { get; set; }
        public float VMDGear { get; set; }


        public int OperatorID { get; set; }

        public DateTime Date { get; set; }


        public double HorizontalSpacerLength { get; set; }

        public double VerticalSpacerLength { get; set; }

        public string Model { get; set; }
        public string Ratio { get; set; }

        public string DriveNumber { get; set; }
        public string GearNumber { get; set; }

        public float? Backlash { get; set; }
        public float? HorizontalSetting { get; set; }
        public float? IntermediateSetting { get; set; }
        public float? OutputSetting { get; set; }
        public string HelicalGearNumber { get; set; }
        public string HelicalPinionNumber { get; set; }
    }
}
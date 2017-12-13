using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FSpacerFinal.Models
{
    public class SpacerCard
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public bool Active { get; set; }

        #region Horizontal Variables and spacer length
        public int HorizontalGearCaseDeviation { get; set; }
        public int HorizontalCarrierDeviation { get; set; }
        public int Bearing { get; set; }
        public float HMDGear { get; set; }
        public double HorizontalSpacerLength { get; set; } //Will be initialized with the class if needed variables are set.
        #endregion

        #region Vertical Variables and spacer length
        public int VerticalGearCaseDeviation { get; set; }
        public int VerticalCarrierDeviation { get; set; }
        public float GearMount { get; set; }
        public float VMDGear { get; set; }
        public double VerticalSpacerLength { get; set; }
        #endregion

        #region Misc Variables
        [ForeignKey("DriveCard")]
        public string DriveNumber { get; set; }
        [ForeignKey("Operator")]
        public int OperatorID { get; set; }
        public DriveCard Drive { get; set; }
        public Operator Operator { get; set; }
        public DateTime Date { get; set; }
        #endregion

        #region Card Back Variables
        //These are set to nullable because they might or might not be set and they will never be used for calculation
        public float? Backlash { get; set; }
        public float? HorizontalSetting { get; set; }
        public float? IntermediateSetting { get; set; }
        public float? OutputSetting { get; set; }
        public string HelicalGearNumber { get; set; }
        public string HelicalPinionNumber { get; set; }
        #endregion

        static private float[,] DriveConstants = new float[5, 10] { {6.455f, 1.4567f, -.0001f, .0005f, 0, 0, 4.582f, 1.4567f, -.0004f, 0},
                                                                 {8.125f, 1.625f, 0, -.0001f, .0001f, 0, 5.25f, 1.8125f, 0, 0},
                                                                 {10, 2.125f, .0003f, -.0001f, 0, 0, 6, 1.8125f, 0, 0},
                                                                 {11.063f, 1.9375f, 0, 0, 0, 0, 7.4375f, 1.9375f, 0, 0},
                                                                 {11.813f, 1.9375f, 0, 0, 0, 0, 7.4375f, 1.9375f, 0, 0} };

        public static int ModelToInt(string model)
        {
            int modelInt;

            switch (model)
            {
                case "F85":
                    modelInt = 0;
                    break;

                case "F110":
                    modelInt = 1;
                    break;

                case "F135":
                    modelInt = 2;
                    break;

                case "F155":
                    modelInt = 3;
                    break;

                case "F175":
                    modelInt = 4;
                    break;

                default:
                    modelInt = 0;
                    break;
            }

            return modelInt;
        }

        public static double GetHorizontalSpacerLength(int model, float horizontalGearCaseDeviation, float horizontalCarrierDeviation, float bearing, float hMDGear)
        {
            if (model != -1)
            {
                double horizontalSpacerLength = (1000 * (DriveConstants[model, 0] + (horizontalGearCaseDeviation / 1000) - (horizontalCarrierDeviation / 1000) - DriveConstants[model, 1] - (bearing / 1000) - hMDGear - (DriveConstants[model, 4]) - (DriveConstants[0, 2]) + (DriveConstants[model, 3]))) / 1000;

                return Math.Round(horizontalSpacerLength, 3);
            }
            else
            {
                return 0.000;
            }
        }

        public static double GetVerticalSpacerLength(int model, float verticalGearCaseDeviation, float verticalCarrierDeviation, float vMDGear, float gearMount)
        {
            if (model != -1)
            {
                float verticalSpacerLength = (1000 * ((DriveConstants[model, 6]) + (verticalGearCaseDeviation / 1000) - (DriveConstants[model, 7]) - (verticalCarrierDeviation / 1000) - (vMDGear + gearMount) + (DriveConstants[model, 8]))) / 1000;

                return Math.Round(verticalSpacerLength, 3);
            }
            else
            {
                return 0.000;
            }

        }

    }
}

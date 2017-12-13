using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSpacerFinal.Models;

namespace FSpacerFinal.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            //check for existing DriveCards
            if (context.DriveCards.Any())
            {
                return; //seeding the application
            }

            var driveCards = new DriveCard[]
            {
                new DriveCard{Model = "F110", DriveNumber = "326292", GearNumber = "BL1349", Ratio = "6.5:1" },
                new DriveCard{Model = "F110", DriveNumber = "326293", GearNumber = "BL3051", Ratio = "5.5:1" },
                new DriveCard{Model = "F110", DriveNumber = "326294", GearNumber = "BL3048", Ratio = "5.5:1" },
                new DriveCard{Model = "F135", DriveNumber = "328593", GearNumber = "BL4593", Ratio = "6.5:1" },
                new DriveCard{Model = "F135", DriveNumber = "328595", GearNumber = "BL4596", Ratio = "6.5:1" }
            };

            foreach (DriveCard d in driveCards)
            {
                context.DriveCards.Add(d);
            }

            var operators = new Operator[]
            {
                new Operator{ FirstName = "Daniel", LastName = "Hix"},
                new Operator{ FirstName = "Alex", LastName = "White"},
                new Operator{ FirstName = "Puneet", LastName = "Cheema"},
                new Operator{ FirstName = "Dwight", LastName = "Lehman"}
            };

            foreach (Operator o in operators)
            {
                context.Operators.Add(o);
            }

            var spacerCards = new SpacerCard[]
            {
                new SpacerCard{HorizontalGearCaseDeviation = 1, HorizontalCarrierDeviation = 0, Bearing = 3, HMDGear = 5.875f, VerticalGearCaseDeviation = 5, VerticalCarrierDeviation = 3, GearMount = 0, VMDGear = 2.955f, DriveNumber = "326294", OperatorID = 1 ,Date = DateTime.ParseExact("20150217", "yyyyMMdd", null), Active = true, Backlash = .021f, HelicalGearNumber = "", HelicalPinionNumber = "" },
                new SpacerCard{HorizontalGearCaseDeviation = 0, HorizontalCarrierDeviation = 0, Bearing = 3, HMDGear = 5.875f, VerticalGearCaseDeviation = 5, VerticalCarrierDeviation = 3, GearMount = 0, VMDGear = 2.955f, DriveNumber = "326293", OperatorID = 1 ,Date = DateTime.ParseExact("20150217", "yyyyMMdd", null), Active = true, Backlash = .031f, HorizontalSetting = .002f, OutputSetting = -.002f, HelicalGearNumber = "", HelicalPinionNumber = "" },
                new SpacerCard{HorizontalGearCaseDeviation = 1, HorizontalCarrierDeviation = 0, Bearing = 3, HMDGear = 5.875f, VerticalGearCaseDeviation = 7, VerticalCarrierDeviation = 3, GearMount = 0, VMDGear = 2.870f, DriveNumber = "326292", OperatorID = 1 ,Date = DateTime.ParseExact("20150216", "yyyyMMdd", null), Active = true, Backlash = .016f, HelicalGearNumber = "", HelicalPinionNumber = "" },
                new SpacerCard{HorizontalGearCaseDeviation = -2, HorizontalCarrierDeviation = 0, Bearing = 4, HMDGear = 7.063f, VerticalGearCaseDeviation = -2, VerticalCarrierDeviation = 3, GearMount = .875f, VMDGear = 2.383f, DriveNumber = "328593", OperatorID = 1 , Date = DateTime.ParseExact("20150604", "yyyyMMdd", null), Active = true, Backlash = .015f, HelicalGearNumber = "", HelicalPinionNumber = ""  },
                new SpacerCard{HorizontalGearCaseDeviation = -1, HorizontalCarrierDeviation = 0, Bearing = 4, HMDGear = 7.063f, VerticalGearCaseDeviation = -4, VerticalCarrierDeviation = 3, GearMount = .875f, VMDGear = 2.383f, DriveNumber = "328595", OperatorID = 1 , Date = DateTime.ParseExact("20150604", "yyyyMMdd", null), Active = true, Backlash = .014f, HorizontalSetting = .003f, OutputSetting = -.003f, HelicalGearNumber = "", HelicalPinionNumber = ""}
            };

            foreach (SpacerCard s in spacerCards)
            {
                var drive = driveCards.Single(d => d.DriveNumber == s.DriveNumber);

                s.HorizontalSpacerLength = SpacerCard.GetHorizontalSpacerLength(SpacerCard.ModelToInt(drive.Model), s.HorizontalGearCaseDeviation, s.HorizontalCarrierDeviation, s.Bearing, s.HMDGear);
                s.VerticalSpacerLength = SpacerCard.GetVerticalSpacerLength(SpacerCard.ModelToInt(drive.Model), s.VerticalGearCaseDeviation, s.VerticalCarrierDeviation, s.VMDGear, s.GearMount);

                context.SpacerCards.Add(s);
            }
              
            context.SaveChanges();

        }
    }
}

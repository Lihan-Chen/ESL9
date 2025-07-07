using System.ComponentModel.DataAnnotations;

namespace Mvc.Models.Enum
{
    public enum Facil
    {        
        OCC = 1,

        Diemer = 2,

        Jensen = 3,

        Mills = 4,

        [Display(Name = "Wey")]
        Weymouth = 5,

        Skinner = 6,

        DOCC = 7,

        Intake = 8,

        Gene = 9,

        Iron = 10,

        Eagle = 11,

        Hinds = 12,
    }

    public abstract class FacilExtensions
    {
        public static string GetFacilName(Facil facil)
        {
            return facil switch
            {
                Facil.OCC => "OCC",
                Facil.Diemer => "Diemer",
                Facil.Jensen => "Jensen",
                Facil.Mills => "Mills",
                Facil.Weymouth => "Weymouth",
                Facil.Skinner => "Skinner",
                Facil.DOCC => "DOCC",
                Facil.Intake => "Intake",
                Facil.Gene => "Gene",
                Facil.Iron => "Iron",
                Facil.Eagle => "Eagle",
                Facil.Hinds => "Hinds",
                //Facil.DVL => "DVL",
                _ => throw new ArgumentOutOfRangeException(nameof(Facil), facil, null)
            };
        }
    }

    public static class FacilHelper
    {
        public static string GetFacilName(int facilNo)
        {
            return ((Facil)facilNo).ToString();
        }

        //public static string GetFacilName(string Facil)
        //{
        //    return Enum.TryParse<Facil>(Facil, out var FacilEnum) ? FacilEnum.ToString() : "";
        //}

        //public static int GetFacilNumber(string Facil)
        //{
        //    return Enum.TryParse<Facil>(Facil, out var FacilEnum) ? (int)FacilEnum : 0;
        //}

        public static int GetFacilNumber(Facil facil)
        {
            return (int)facil;
        }

        //public static string GetFacilName(Facil facil, bool isAbbreviation)
        //{
        //    return isAbbreviation ? GetFacilName(Facil).Substring(0, 3) : GetFacilName(Facil);
        //}

        //public static string[] GetFacilNames()
        //{
        //    return [..Enum.GetValues<Facil>()
        //               .Select(p => GetFacilName(Convert.ToInt32(p)))];

        //    //return Enum.GetValues<Facil>()
        //    //           .Select(p => GetFacilName(Convert.ToInt32(p)))
        //    //           .ToArray(); // Fix: Convert the List<string> to a string[] using ToArray()
        //}

        // Converts the enumerable of Facil values into a dictionary with Name as key and Value as value.
        //public static Dictionary<string, int> FacilList()
        //{
        //    return Enum.GetValues<Facil>()
        //               .ToDictionary(p => p.ToString(), p => (int)p);
        //}

        //public static int GetFacilNo(string facilName)
        //{
        //    // return Enum.TryParse<Facil>(facilName, out var Facil) ? (int)Facil : 0;

        //    //From the dictionary above other than the convention of Facils[FacilName]
        //    var FacilList = FacilList();
        //    if (FacilList.TryGetValue(FacilName, out int FacilNo))
        //    {
        //        return facilNo;
        //    }
        //    else
        //    {
        //        return 0; // or throw an exception, or handle it as needed
        //    }
        //}
    }
}


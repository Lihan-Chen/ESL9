namespace Prototype.Models
{
    public enum Facil
    {
        OCC = 1,

        Diemer = 2,

        Jensen = 3,

        Mills = 4,

        Weymouth = 5,

        Skinner = 6,

        DOCC = 7,

        Intake = 8,

        Gene = 9,

        Iron = 10,

        Eagle = 11,

        Hinds = 12,

        //DVL = 13
    }

    public abstract class FacilityOptionExtensions
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
                //Plant.DVL => "DVL",
                _ => throw new ArgumentOutOfRangeException(nameof(facil), facil, null)
            };
        }
    }

    public static class FacilHelper
    {
        public static string GetFacilName(int facil)
        {
            return ((Facil)facil).ToString();
        }

        //public static string GetPlantName(string plant)
        //{
        //    return Enum.TryParse<Plant>(plant, out var plantEnum) ? plantEnum.ToString() : "Unknown";
        //}

        //public static int GetPlantNumber(string plant)
        //{
        //    return Enum.TryParse<Plant>(plant, out var plantEnum) ? (int)plantEnum : 0;
        //}

        public static int GetFacilNumber(Facil facil)
        {
            return (int)facil;
        }

        //public static string GetPlantName(Plant plant, bool isAbbreviation)
        //{
        //    return isAbbreviation ? GetPlantName(plant).Substring(0, 3) : GetPlantName(plant);
        //}

        //public static string[] GetPlantNames()
        //{
        //    return [..Enum.GetValues<Plant>()
        //               .Select(p => GetPlantName(Convert.ToInt32(p)))];

        //    //return Enum.GetValues<Plant>()
        //    //           .Select(p => GetPlantName(Convert.ToInt32(p)))
        //    //           .ToArray(); // Fix: Convert the List<string> to a string[] using ToArray()
        //}

        // Converts the enumerable of Plant values into a dictionary with Name as key and Value as value.
        //public static Dictionary<string, int> PlantList()
        //{
        //    return Enum.GetValues<Plant>()
        //               .ToDictionary(p => p.ToString(), p => (int)p);
        //}

        //public static int GetPlantNo(string plantName)
        //{
        //    // return Enum.TryParse<Plant>(plantName, out var plant) ? (int)plant : 0;

        //    //From the dictionary above other than the convention of plants[plantName]
        //    var plantList = PlantList();
        //    if (plantList.TryGetValue(plantName, out int plantNo))
        //    {
        //        return plantNo;
        //    }
        //    else
        //    {
        //        return 0; // or throw an exception, or handle it as needed
        //    }
        //}
    }
}

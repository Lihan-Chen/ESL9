namespace Core.Models.Enums
{
    public enum Plant
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

        DVL = 13
    }

    public abstract class PlantExtensions
    {
        public static string GetPlantName(Plant plant)
        {
            return plant switch
            {
                Plant.OCC => "OCC",
                Plant.Diemer => "Diemer",
                Plant.Jensen => "Jensen",
                Plant.Mills => "Mills",
                Plant.Weymouth => "Weymouth",
                Plant.Skinner => "Skinner",
                Plant.DOCC => "DOCC",
                Plant.Intake => "Intake",
                Plant.Gene => "Gene",
                Plant.Iron => "Iron",
                Plant.Eagle => "Eagle",
                Plant.Hinds => "Hinds",
                Plant.DVL => "DVL",
                _ => throw new ArgumentOutOfRangeException(nameof(plant), plant, null)
            };
        }
    }

    public static class PlantHelper
    {
        public static string GetPlantName(int plant)
        {
            return ((Plant)plant).ToString();
        }

        public static string GetPlantName(string plant)
        {
            return Enum.TryParse<Plant>(plant, out var plantEnum) ? plantEnum.ToString() : "Unknown";
        }

        public static int GetPlantNumber(string plant)
        {
            return Enum.TryParse<Plant>(plant, out var plantEnum) ? (int)plantEnum : 0;
        }

        public static int GetPlantNumber(Plant plant)
        {
            return (int)plant;
        }

        //public static string GetPlantName(Plant plant, bool isAbbreviation)
        //{
        //    return isAbbreviation ? GetPlantName(plant).Substring(0, 3) : GetPlantName(plant);
        //}

        public static string[] GetPlantNames()
        {
            return [..Enum.GetValues<Plant>()
                       .Select(p => GetPlantName(Convert.ToInt32(p)))];                       

            //return Enum.GetValues<Plant>()
            //           .Select(p => GetPlantName(Convert.ToInt32(p)))
            //           .ToArray(); // Fix: Convert the List<string> to a string[] using ToArray()
        }

        // Converts the enumerable of Plant values into a dictionary with Name as key and Value as value.
        public static Dictionary<string, int> PlantList()
        {
            return Enum.GetValues<Plant>()
                       .ToDictionary(p => p.ToString(), p => (int)p);           
        }

        public static int GetPlantNo(string plantName)
        {
            // return Enum.TryParse<Plant>(plantName, out var plant) ? (int)plant : 0;

            //From the dictionary above other than the convention of plants[plantName]
            var plantList = PlantList();
            if (plantList.TryGetValue(plantName, out int plantNo))
            {
                return plantNo;
            }
            else
            {
                return 0; // or throw an exception, or handle it as needed
            }
        }

        //using Microsoft.AspNetCore.Mvc.Rendering;
        //public static SelectList ToPlantSelectList()
        //{
        //    var plants = PlantList();
        //    return new SelectList(plants, "Value", "Key");
        //}

        //public static SelectList ToPlantSelectList(int selectedValue)
        //{
        //    var plants = PlantList();
        //    return new SelectList(plants, "Value", "Key", selectedValue);
        //}

        //@* In your Razor view *@
        //<select asp-for="SelectedPlant" asp-items="@Model.PlantOptions">
        //    <option value = "" > Select a plant...</option>
        //</select>

        //using Microsoft.AspNetCore.Mvc.Rendering;

        //public static List<SelectListItem> ToPlantImageList()
        //{
        //    return PlantList()
        //        .Select(p => new SelectListItem
        //        {
        //            Value = p.Value.ToString(),
        //            Text = p.Key,
        //            // Assuming images are stored in wwwroot/images/plants/
        //            Group = new SelectListGroup
        //            {
        //                Name = $"/images/plants/{p.Key.ToLower()}.png"
        //            }
        //        })
        //        .ToList();
        //}

        //<div class="plant-selector">
        //    @foreach(var plant in Model.PlantImages)
        //        {
        //            < label class="plant-option">
        //                <input type = "radio"
        //                       name="SelectedPlant" 
        //                       value="@plant.Value" 
        //                       @(Model.SelectedPlant.ToString() == plant.Value? "checked" : "")>
        //                <img src = "@plant.Group.Name"
        //                     alt="@plant.Text" 
        //                     title="@plant.Text" 
        //                     class="plant-image">
        //                <span class="plant-name">@plant.Text</span>
        //            </label>
        //        }
        //</div>

        //<style>
        //    .plant-selector {
        //        display: flex;
        //        flex-wrap: wrap;
        //        gap: 1rem;
        //    }

        //    .plant - option {
        //        display: flex;
        //            flex - direction: column;
        //            align - items: center;
        //        cursor: pointer;
        //        }

        //    .plant - option input[type = "radio"] {
        //        display: none;
        //        }

        //    .plant - image {
        //        width: 100px;
        //        height: 100px;
        //        border: 2px solid transparent;
        //            border - radius: 8px;
        //        padding: 4px;
        //        }

        //    .plant - option input[type = "radio"]:checked + .plant - image {
        //        border - color: #007bff;
        //        }

        //    .plant - name {
        //        margin - top: 0.5rem;
        //        font - weight: 500;
        //        }
        //</ style >

        //@section Scripts {
        //< script >
        //    document.querySelectorAll('.plant-option').forEach(option => {
        //    option.addEventListener('click', function() {
        //        const radio = this.querySelector('input[type="radio"]');
        //        radio.checked = true;
        //        // Trigger form submission or other actions if needed
        //        });
        //    });
        //</ script >
        //}

        //Important notes:
        //1.	Create a wwwroot/images/plants/ directory in your project
        //2.	Add plant images named according to the enum values (e.g., occ.png, diemer.png, etc.)
        //3.	Image names should match the lowercase plant names
        //4.	Ensure your images are of consistent size/aspect ratio
        //This implementation:
        //•	Creates clickable image tiles for each plant
        //•	Shows the plant name below each image
        //•	Provides visual feedback for selection
        //•	Is keyboard accessible
        //•	Works with form submissions
        //•	Is responsive and will wrap on smaller screens
        //Remember to adjust the image paths, sizes, and styling to match your project's requirements and design system.
    }
}

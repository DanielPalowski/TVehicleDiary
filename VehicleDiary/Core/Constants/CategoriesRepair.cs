namespace VehicleDiary.Core.Constants
{
    public class CategoriesRepair
    {
        // Hlavní kategorie (RepairVCategory)
        public const string VehicleRepairs = "Vehicle Repairs";
        public const string VehicleUpgrades = "Vehicle Upgrades";
        public const string Diagnostics = "Diagnostics";

        // Typy pro Vehicle Repairs (RepairVType)
        public const string Engine = "Engine";
        public const string Transmission = "Transmission";
        public const string Brakes = "Brakes";
        public const string Chassis = "Chassis";
        public const string Electrical = "Electrical";
        public const string Bodywork = "Bodywork";
        public const string AirConditioning = "Air Conditioning";

        // Typy pro Vehicle Upgrades (RepairVType)
        public const string Retrofit = "Retrofit";
        public const string Performance = "Performance";
        public const string Style = "Style";
        public const string Interior = "Interior";
        public const string Accessories = "Accessories";

        // Typy pro Diagnostics (RepairVType)
        public const string Coding = "Coding";
        public const string ErrorDiagnostics = "Error Diagnostics";
        public const string SoftwareUpdate = "Software Update";

        // Metody pro získání typů podle kategorie
        public static List<string> GetTypesForCategory(string category)
        {
            return category switch
            {
                VehicleRepairs => new List<string>
                    { Engine, Transmission, Brakes, Chassis, Electrical, Bodywork, AirConditioning },
                VehicleUpgrades => new List<string>
                    { Retrofit, Performance, Style, Interior, Accessories },
                Diagnostics => new List<string>
                    { Coding, ErrorDiagnostics, SoftwareUpdate },
                _ => new List<string>()
            };
        }

        public static List<string> GetAllCategories()
            => new List<string> { VehicleRepairs, VehicleUpgrades, Diagnostics };
    }
}

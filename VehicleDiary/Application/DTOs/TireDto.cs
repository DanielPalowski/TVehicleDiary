namespace VehicleDiary.Application.DTOs
{
    public class TireDto
    {
        public Guid Id { get; set; }
        public float TirePrice { get; set; }
        public int TireAmount { get; set; }
        public string TireBrand { get; set; }
        public int TireType { get; set; }
        public string TireSize { get; set; }
        public DateTime TireDate { get; set; }
        public float? TireChangedPrice { get; set; }
        public string? TireShopWhereBought { get; set; }
        public string? TireDescription { get; set; }
        public Guid VehicleId { get; set; }
    }
}

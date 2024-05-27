namespace SustainableHospitalWaste.Entities
{
    internal class WasteItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GroupId { get; set; }

        public WasteGroup Group { get; set; }
    }
}

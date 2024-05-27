using System;

namespace SustainableHospitalWaste.Entities
{
    internal class DisposalReport
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ItemId { get; set; }

        public WasteItem Item { get; set; }

        public DateTime DataReport { get; set; }

        public int Quantity { get; set; }

        public string Remarks { get; set; }
    }
}

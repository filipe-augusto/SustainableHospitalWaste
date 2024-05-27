using SustainableHospitalWaste.Entities;
using System.Collections.Generic;

namespace SustainableHospitalWaste.Data.Interfaces
{
    public interface IWasteGroupData
    {
        void Create(WasteGroup wasteGroup);
        WasteGroup Read(int id);
        List<WasteGroup> ReadAll();
        void Update(WasteGroup wasteGroup);
        void Delete(int id);
    }
}

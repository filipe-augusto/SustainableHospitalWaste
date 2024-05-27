using SustainableHospitalWaste.Entities;
using System.Collections.Generic;

namespace SustainableHospitalWaste.Business.Interfaces
{
    public interface IWasteGroupBusiness
    {
        void Create(WasteGroup wasteGroup);
        WasteGroup Read(int id);
        List<WasteGroup> ReadAll();
        void Update(WasteGroup wasteGroup);
        void Delete(int id);
    }
}

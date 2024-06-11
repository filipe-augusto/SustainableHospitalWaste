using SustainableHospitalWaste.Business.Interfaces;
using SustainableHospitalWaste.Data.Interfaces;
using SustainableHospitalWaste.Entities;
using System;
using System.Collections.Generic;

namespace SustainableHospitalWaste.Business.Repositories
{
    public class WasteGroupBusiness : IWasteGroupBusiness
    {
        private readonly IWasteGroupData _wasteGroupData;

        public WasteGroupBusiness(IWasteGroupData wasteGroupData)
        {
            _wasteGroupData = wasteGroupData;
        }

        public void Create(WasteGroup wasteGroup)
        {
            if (string.IsNullOrEmpty(wasteGroup.Name))
                throw new ArgumentException("O nome do grupo de resíduos não pode estar vazio.");

            _wasteGroupData.Create(wasteGroup);
        }

        public WasteGroup Read(int id)
        {
            return _wasteGroupData.Read(id);
        }

        public List<WasteGroup> ReadAll()
        {
            return _wasteGroupData.ReadAll();
        }

        public void Update(WasteGroup wasteGroup)
        {
            if (wasteGroup.Id <= 0)
                throw new ArgumentException("ID do grupo de resíduos inválido.");

            _wasteGroupData.Update(wasteGroup);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID do grupo de resíduos inválido.");

            _wasteGroupData.Delete(id);
        }
    }
}

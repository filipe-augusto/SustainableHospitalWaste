using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SustainableHospitalWaste.Business.Interfaces;
using SustainableHospitalWaste.Business.Repositories;
using SustainableHospitalWaste.Data.Interfaces;
using SustainableHospitalWaste.Entities;
using System;
using System.Collections.Generic;

namespace SustainableHospitalWaste.Tests
{
    [TestClass]
    public class GroupBusinessTests
    {

        private Mock<IWasteGroupData> _mockWasteGroupData;
        private IWasteGroupBusiness _wasteGroupBusiness;

        [TestInitialize]
        public void Setup()
        {
            _mockWasteGroupData = new Mock<IWasteGroupData>();
            _wasteGroupBusiness = new WasteGroupBusiness(_mockWasteGroupData.Object);
        }

        [TestMethod]
        public void AddWasteGroup_ValidWasteGroup_ShouldCallCreateMethodOnce()
        {
            // Arrange
            var wasteGroup = new WasteGroup { Name = "Group 1" };

            // Act
            _wasteGroupBusiness.Create(wasteGroup);

            // Assert
            _mockWasteGroupData.Verify(wg => wg.Create(It.IsAny<WasteGroup>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWasteGroup_InvalidWasteGroup_ShouldThrowArgumentException()
        {
            // Arrange
            var wasteGroup = new WasteGroup { Name = "" };

            // Act
            _wasteGroupBusiness.Create(wasteGroup);

            // Assert is handled by ExpectedException
        }
        [TestMethod]
        public void GetWasteGroup_ValidId_ShouldReturnWasteGroup()
        {
            // Arrange
            var wasteGroup = new WasteGroup { Id = 1, Name = "Group 1" };
            _mockWasteGroupData.Setup(wg => wg.Read(1)).Returns(wasteGroup);

            // Act
            var result = _wasteGroupBusiness.Read(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void ListWasteGroups_ShouldReturnListOfWasteGroups()
        {
            // Arrange
            var wasteGroups = new List<WasteGroup>
            {
                new WasteGroup { Id = 1, Name = "Group 1" },
                new WasteGroup { Id = 2, Name = "Group 2" }
            };
            _mockWasteGroupData.Setup(wg => wg.ReadAll()).Returns(wasteGroups);

            // Act
            var result = _wasteGroupBusiness.ReadAll();

            // Assert
            Assert.AreEqual(2, result.Count);
        }
    }
}

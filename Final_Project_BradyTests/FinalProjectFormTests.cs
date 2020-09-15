using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Final_Project_Brady.Tests
{
    [TestClass()]
    public class FinalProjectFormTests
    {
        [TestMethod()]
        public void ValidateIDLengthTest() //tests invalid ID length
        {
            //Arrange
            string id = "90090000";
            FinalProjectForm newClass = new FinalProjectForm();
            
            //Act/assert
            Assert.ThrowsException<ArgumentException>(() => newClass.ValidateID(id));
        }

        [TestMethod()]
        public void ValidateIDNumOnlyTest() //tests invalid ID
        {
            //Arrange
            string id = "900ABCDEF";
            FinalProjectForm newClass = new FinalProjectForm();

            //Act
            newClass.ValidateID(id);

            //Assert
            Assert.IsTrue(newClass.invalidID);
        }

        [TestMethod()]
        public void ValidateName() //tests name containing numbers and invalid characters
        {
            //Arrange
            string name = "Kabrina123!";
            FinalProjectForm newClass = new FinalProjectForm();

            //Act/assert
            Assert.ThrowsException<ArgumentException>(() => newClass.ValidateName(name));
        }

        [TestMethod()]
        public void ValidateNameWithHypenAndApostrophe() //tests name containing hyphen and apostrophe
        {
            //Arrange
            string name = "O'Brien-Cortez";
            FinalProjectForm newClass = new FinalProjectForm();
            
            //Act
            newClass.ValidateName(name);

            //Assert
            Assert.IsFalse(newClass.invalidName);
        }

        [TestMethod()]
        public void ValidateNameNoSymbols() //tests name that doesn't contain symbols
        {
            //Arrange
            string name = "Kabrina";
            FinalProjectForm newClass = new FinalProjectForm();

            //Act
            newClass.ValidateName(name);

            //Assert
            Assert.IsFalse(newClass.invalidName);
        }

        [TestMethod()]
        public void ValidateValidIDTest() //tests invalid ID length
        {
            //Arrange
            string id = "123456789";
            FinalProjectForm newClass = new FinalProjectForm();

            //Act
            newClass.ValidateID(id);

            //Assert
            Assert.IsFalse(newClass.invalidID);
        }
    }
}
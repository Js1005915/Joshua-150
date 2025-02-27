using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalKingdom; // Replace with the actual namespace of your Animal classes

namespace AnimalTests
{
    [TestClass]
    public class AnimalInheritanceTests
    {
        [TestMethod]
        public void Bird_MakeSound_ReturnsCorrectSound()
        {
            // Arrange
            var bird = new Bird("Parrot", 5);
            var expectedSound = "Parrot chirps.";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                bird.MakeSound();

                // Assert
                var result = sw.ToString().Trim();
                Assert.AreEqual(expectedSound, result);
            }
        }

        [TestMethod]
        public void Fish_MakeSound_ReturnsCorrectSound()
        {
            // Arrange
            var fish = new Fish("Goldfish", 1);
            var expectedSound = "Goldfish bubbles.";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                fish.MakeSound();

                // Assert
                var result = sw.ToString().Trim();
                Assert.AreEqual(expectedSound, result);
            }
        }

        [TestMethod]
        public void Bird_InitializedWithCorrectValues()
        {
            // Arrange
            var bird = new Bird("Parrot", 5);

            // Act & Assert
            Assert.AreEqual("Parrot", bird.Name);
            Assert.AreEqual(5, bird.Age);
        }

        [TestMethod]
        public void Fish_InitializedWithCorrectValues()
        {
            // Arrange
            var fish = new Fish("Goldfish", 1);

            // Act & Assert
            Assert.AreEqual("Goldfish", fish.Name);
            Assert.AreEqual(1, fish.Age);
        }
    }
}
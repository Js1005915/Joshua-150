using LargestNumberFinder;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Exam_1_Test
{
    [TestClass]
    public class NumberProcessorTests
    {
        [TestMethod]
        public void ProcessInput_ShouldUpdateLargest_WhenNewNumberIsLarger()
        {
            int largest = 5;
            int result = NumberProgram.ProcessInput("10", ref largest);
            Assert.AreEqual(10, largest);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void ProcessInput_ShouldNotUpdateLargest_WhenNewNumberIsNotLarger()
        {
            int largest = 20;
            int result = NumberProgram.ProcessInput("10", ref largest);
            Assert.AreEqual(20, largest);
            Assert.AreEqual(10, result);
        }

    }
}
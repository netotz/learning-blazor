
using Xunit;

namespace LearningBlazor.Tests {
    public class DummyTest {
        
        /// <summary>
        /// Expected to pass.
        /// </summary>
        [Fact]
        public void Add_AddingZero_ReturnsSameNumber() {
            var onePlusZero = 1 + 0;
            Assert.Equal(1, onePlusZero);
        }

        /// <summary>
        /// Expected to fail.
        /// </summary>
        [Fact]
        public void Add_AddingSameNumber_ReturnsDouble() {
            var onePlusOne = 1 + 1;
            Assert.Equal(0, onePlusOne);
        }
    }
}

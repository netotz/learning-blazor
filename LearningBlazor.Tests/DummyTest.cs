
using Xunit;

namespace LearningBlazor.Tests {
    public class DummyTest {
        
        [Fact]
        public void Add_AddingZero_ReturnsSameNumber() {
            var onePlusZero = 1 + 0;
            Assert.Equal(1, onePlusZero);
        }
    }
}

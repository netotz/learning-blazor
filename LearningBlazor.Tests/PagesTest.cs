using Bunit;

using LearningBlazorWASM.Pages;

using Xunit;

namespace LearningBlazor.Tests {

    public class PagesTest {

        /// <summary>
        /// The first click on the Counter component should set it to its property <c>CurrentCount</c>.
        /// </summary>
        [Fact]
        public void IncrementCount_FirstClick_CounterIsOne() {
            using var context = new TestContext();
            var counter = context.RenderComponent<Counter>();

            counter.Find("button").Click();
            var actual = Counter.CurrentCount;

            counter.Find("p").MarkupMatches($"<p>Current count: {actual}</p>");
        }
    }
}
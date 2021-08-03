using Xunit;
namespace drone_delivery
{
    public class testclass
    {

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyTheory(int myNum)
        {
            Assert.True(Program.isOdd(myNum));
        }

        [Fact]
        public void PassingAaddTest()
        {
            Assert.Equal(4, Program.Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.NotEqual(5, Program.Add(2, 2));
        }
    }
}
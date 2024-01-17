using Microsoft.CSharp.RuntimeBinder;
using TestProject.ClassesUnderTest;

namespace TestProject
{
    public class MathUtilsTests
    {
        // Test for the Add method with integer parameters
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-4, 2, -2)]
        public void TestAdd_Int(int a, int b, int expectedResult)
        {
            int result = MathUtils.Add(a, b);
            Assert.Equal(expectedResult, result);
        }

        // Test for the Add method with double parameters and precision check
        [Fact]
        public void TestAdd_Double()
        {
            double expectedResult = 0.3;
            double result = 0.1 + 0.2;

            Assert.Equal(expectedResult, result, precision: 1);
        }

        // Test for the Add method with non-numeric parameters, expecting an exception
        [Fact]
        public void TestAdd_Throws()
        {
            DisjointSet<int> disjointSet1 = new();
            DisjointSet<int> disjointSet2 = new();

            Assert.Throws<RuntimeBinderException>(
                () => MathUtils.Add(disjointSet1, disjointSet2)
                );
        }
    }
}

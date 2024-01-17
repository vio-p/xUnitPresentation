using TestProject.ClassesUnderTest;

namespace TestProject
{
    public class DisjointSetTests
    {
        private readonly DisjointSet<int> _disjointSet;

        public DisjointSetTests()
        {
            _disjointSet = new DisjointSet<int>();
        }

        // Test for the MakeSet method with positive scenarios
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void TestMakeSet_Positive(int data)
        {
            bool result = _disjointSet.MakeSet(data);
            Assert.True(result);
            Assert.True(_disjointSet.ContainsData(data));
        }

        // Test for the MakeSet method with negative scenario (trying to make a set with existing data)
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void TestMakeSet_Negative(int data)
        {
            _ = _disjointSet.MakeSet(data);
            bool result = _disjointSet.MakeSet(data);
            Assert.False(result);
        }

        // Test for the FindSet method
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void TestFindSet(int data)
        {
            _ = _disjointSet.MakeSet(data);
            Assert.Equal(data, _disjointSet.FindSet(data));
        }

        // Test for the Union method
        [Theory]
        [InlineData(0, 1)]
        [InlineData(2, 3)]
        [InlineData(4, 5)]
        public void TestUnion(int data1, int data2)
        {
            _ = _disjointSet.MakeSet(data1);
            _ = _disjointSet.MakeSet(data2);
            _disjointSet.Union(data1, data2);

            Assert.Equal(_disjointSet.FindSet(data1), _disjointSet.FindSet(data2));
        }
    }
}
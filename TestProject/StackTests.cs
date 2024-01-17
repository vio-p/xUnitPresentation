namespace TestProject
{
    // Test fixture for StackTests
    public class StackFixture : IDisposable
    {
        public StackFixture()
        {
            Stack = new Stack<int>();
        }

        public void Dispose()
        {
            Stack.Clear();
        }

        public Stack<int> Stack { get; private set; }
    }

    // Custom TestCaseOrderer specified for test method ordering
    [TestCaseOrderer(
        ordererTypeName: "TestProject.PriorityOrderer",
        ordererAssemblyName: "TestProject")]
    public class StackTests : IClassFixture<StackFixture>
    {
        private readonly StackFixture _fixture;

        public StackTests(StackFixture fixture)
        {
            _fixture = fixture;
        }

        // Test for Pop method with priority 0
        [Fact]
        [TestPriority(0)]
        public void TestPush()
        {
            _fixture.Stack.Push(1);
            Assert.Single(_fixture.Stack, 1);
        }

        // Test for Pop method with priority 1
        [Fact]
        [TestPriority(1)]
        public void TestPop()
        {
            int value = _fixture.Stack.Pop();
            Assert.Empty(_fixture.Stack);
            Assert.Equal(1, value);
        }
    }
}

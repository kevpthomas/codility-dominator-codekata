using System;
using Bogus;
using Moq;
using Moq.AutoMock;

namespace Dominator
{
    public abstract class UnitTestBase<TUnderTest>
        where TUnderTest : class
    {
        private TUnderTest _testInstance;
        protected TUnderTest TestInstance => _testInstance ?? (_testInstance = AutoMocker.CreateInstance<TUnderTest>());

        protected AutoMocker AutoMocker;

        protected UnitTestBase()
        {
            AutoMocker = new AutoMocker(MockBehavior.Loose);
        }

        protected Faker Faker => new Faker();

        protected T CreateMock<T>(MockBehavior mockBehaviour = MockBehavior.Loose) where T : class
        {
            return new Mock<T>(mockBehaviour).Object;
        }

        protected T CreateMock<T>(MockBehavior mockBehaviour = MockBehavior.Loose, params object[] args) where T : class
        {
            return new Mock<T>(mockBehaviour, args).Object;
        }

        protected T GetDependency<T>() where T : class 
        {
            return AutoMocker.GetMock<T>().Object;
        }

        public virtual void Dispose()
        {
            _testInstance = null;
        }
    }
}
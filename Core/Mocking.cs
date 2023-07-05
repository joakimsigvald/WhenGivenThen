using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace WhenGivenThen
{
    /// <summary>
    /// Not intended for direct override. Override one of TestStatic, TestStaticAsync, TestSubject or TestSubjectAsync instead
    /// </summary>
    public abstract class Mocking : IMocking
    {
        private readonly IDictionary<Type, Mock> _mocks = new Dictionary<Type, Mock>();

        protected Mocking() => CultureInfo.CurrentCulture = GetCulture();

        public Mock<TObject> GetMock<TObject>() where TObject : class
            => _mocks.TryGetValue(typeof(TObject), out var mock) ? (Mock<TObject>)mock : null;

        /// <summary>
        /// Override this to set different Culture than InvariantCulture during test
        /// </summary>
        /// <returns></returns>
        protected virtual CultureInfo GetCulture() => CultureInfo.InvariantCulture;

        protected TObject The<TObject>() where TObject : class => Mocked<TObject>().Object;

        protected TObject The<TObject, TReturnDefault>(TReturnDefault isDefault)
            where TObject : class
            => Mocked<TObject, TReturnDefault>(isDefault).Object;

        protected Mock<TObject> Mocked<TObject>() where TObject : class
            => Mocked<TObject, TObject>(_ => _);

        protected Mock<TObject> Mocked<TObject, TReturnDefault>(TReturnDefault isDefault)
            where TObject : class
            => Mocked<TObject, TReturnDefault>(mo => isDefault);

        private Mock<TObject> Mocked<TObject, TDefault>(Func<TObject, TDefault> getDefault)
            where TObject : class
            => Mocked(() => MockWithReturnsDefault(getDefault));

        private Mock<TObject> MockWithReturnsDefault<TObject, TDefault>(Func<TObject, TDefault> getDefault)
            where TObject : class
        {
            var mock = new Mock<TObject>();
            mock.SetReturnsDefault(getDefault(mock.Object));
            return mock;
        }

        private Mock<TObject> Mocked<TObject>(Func<Mock<TObject>> mockIt) where TObject : class
            => GetMock<TObject>() ?? (Mock<TObject>)(_mocks[typeof(TObject)] = mockIt());
    }
}
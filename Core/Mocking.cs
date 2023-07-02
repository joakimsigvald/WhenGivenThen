using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace WhenGivenThen
{
    /// <summary>
    /// Not intended for override. Override one of TestStatic, TestStaticAsync, TestSubject or TestSubjectAsync instead
    /// </summary>
    public abstract class Mocking
    {
        internal protected Mocking() => CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        private readonly IDictionary<Type, Mock> _mocks = new Dictionary<Type, Mock>();

        protected TObject The<TObject>() where TObject : class
            => Mocked<TObject>().Object;

        protected TObject The<TObject, TReturnDefault>(TReturnDefault isDefault)
            where TObject : class
            => Mocked<TObject, TReturnDefault>(isDefault).Object;

        protected Mock<TObject> Mocked<TObject, TReturnDefault>(TReturnDefault isDefault)
            where TObject : class
            => Mocked<TObject, TReturnDefault>(mo => isDefault);

        protected Mock<TObject> Mocked<TObject>() where TObject : class
            => Mocked<TObject, TObject>(_ => _);

        internal Mock<TObject> Mocked<TObject, TDefault>(Func<TObject, TDefault> getDefault)
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
            => (Mock<TObject>)(_mocks.TryGetValue(typeof(TObject), out var mock)
            ? mock
            : _mocks[typeof(TObject)] = mockIt());
    }
}
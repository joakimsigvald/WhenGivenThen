using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

namespace Applique.WhenGivenThen.Core
{
    /// <summary>
    /// Not intended for override. Override one of TestStatic, TestStaticAsync, TestSubject or TestSubjectAsync instead
    /// </summary>
    public abstract class Mocking
    {
        internal protected Mocking() => CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        private readonly IDictionary<Type, Mock> _mocks = new Dictionary<Type, Mock>();

        protected void Verify<TObject>() where TObject : class
            => Mocked<TObject>().Verify();

        protected void Verify<TObject>(Expression<Action<TObject>> expression) where TObject : class
            => Mocked<TObject>().Verify(expression);

        protected void Verify<TObject>(Expression<Action<TObject>> expression, Times times)
            where TObject : class
            => Mocked<TObject>().Verify(expression, times);

        protected void Verify<TObject>(Expression<Action<TObject>> expression, Func<Times> times)
            where TObject : class
            => Mocked<TObject>().Verify(expression, times);

        protected void Verify<TObject, TReturns>(Expression<Func<TObject, TReturns>> expression)
            where TObject : class
            => Mocked<TObject>().Verify(expression);

        protected void Verify<TObject, TReturns>(Expression<Func<TObject, TReturns>> expression, Times times)
            where TObject : class
            => Mocked<TObject>().Verify(expression, times);

        protected void Verify<TObject, TReturns>(Expression<Func<TObject, TReturns>> expression, Func<Times> times)
            where TObject : class
            => Mocked<TObject>().Verify(expression, times);

        protected TObject MockOf<TObject>() where TObject : class
            => Mocked<TObject>().Object;

        protected TObject MockOf<TObject, TReturnDefault>(TReturnDefault isDefault)
            where TObject : class
            => Mocked<TObject, TReturnDefault>(isDefault).Object;

        protected Mock<TObject> Mocked<TObject, TReturnDefault>(TReturnDefault isDefault)
            where TObject : class
            => Mocked<TObject, TReturnDefault>(mo => isDefault);

        protected Mock<TObject> Mocked<TObject>() where TObject : class
            => Mocked<TObject, TObject>(_ => _);

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
            => (Mock<TObject>)(_mocks.TryGetValue(typeof(TObject), out var mock)
            ? mock
            : _mocks[typeof(TObject)] = mockIt());
    }
}
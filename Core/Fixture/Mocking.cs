﻿using Moq;
using Moq.AutoMock;
using System.Globalization;

namespace WhenGivenThen.Fixture;

/// <summary>
/// Not intended for direct override. Override one of TestStatic, TestStaticAsync, TestSubject or TestSubjectAsync instead
/// </summary>
public abstract class Mocking : Verification.IMocked
{
    protected readonly AutoMocker Mocker;
    
    protected Mocking()
    {
        CultureInfo.CurrentCulture = GetCulture();
        var defaultProvider = new FluentDefaultProvider
        {
            DefaultMocker = new(MockBehavior.Loose, DefaultValue.Mock)
        };
        Mocker = new(MockBehavior.Loose, DefaultValue.Custom, defaultProvider, false);
    }

    public Mock<TObject> GetMock<TObject>() where TObject : class => Mocker.GetMock<TObject>();

    /// <summary>
    /// Override this to set different Culture than InvariantCulture during test
    /// </summary>
    /// <returns></returns>
    protected virtual CultureInfo GetCulture() => CultureInfo.InvariantCulture;

    protected TObject The<TObject>() where TObject : class => GetMock<TObject>().Object;
}
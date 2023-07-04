using System;

namespace WhenGivenThen;

public class MoreThanOneTestMethod : InvalidOperationException
{
    public MoreThanOneTestMethod() : base("A TestMethod has already been given, by calling When()") { }
}
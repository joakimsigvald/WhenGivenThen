using System;

namespace Joakimsigvald.WhenGivenThen;

public class MoreThanOneTestMethod : InvalidOperationException
{
    public MoreThanOneTestMethod() : base("Both Action and Func cannot be overriden in the same test class") { }
}
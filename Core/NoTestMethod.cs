using System;

namespace Joakimsigvald.WhenGivenThen;

public class NoTestMethod : InvalidOperationException
{
    public NoTestMethod() : base("Either Action or Func must be overriden to call the method to be tested") { }
}
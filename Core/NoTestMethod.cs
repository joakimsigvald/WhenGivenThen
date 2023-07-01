using System;

namespace Applique.WhenGivenThen.Core;

public class NoTestMethod : InvalidOperationException
{
    public NoTestMethod() : base("Either Action or Func must be overriden to call the method to be tested") { }
}

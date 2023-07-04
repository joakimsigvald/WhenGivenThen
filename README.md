# Unit test When (invoke method) Given (input/preconditions) Then (Expected result)

All-inclusive framework for writing and running automated tests in Visual Studio, 
based on the popular "Given-When-Then" pattern. Built upon XUnit and Moq, referencing Test SDK and runner, and including a fluent assertion framework.

Whether you are beginner or expert in unit-testing, this framework will help you write more descriptive tests with less code.

## Usage

* It is recommended to create tests in a separate project from the production code, named [MyProject].Test
* The test-project should mimmic the production project's folder structure, but in addition have one folder for each class to test. 
* Within that folder, one test-class and file should be created per method to test.

### Test a static function with return value
* To test a static method `[MyClass.MyMethod]` returning `[ReturnType]`, Create a new abstract class named `When[MyMethod]` inheriting `WhenGivenThen.TestStatic<[ReturnType]>`.
* Create a protected parameterless constructor that calls `When` with a lambda expression calling the method to test: `When(() => [MyClass].[MyMethod]([Args...]))`.
* Each argument has to be defined as a protected field at the top of the class.

* For each set of preconditions you want to test, Create a nested class within the When-class with the name `Given[SomePrecondition]` inheriting the outer class.
* Override the method `Given` to assign values to the arguments of the method-to-test
 
* Finally, create a test method, attributed with [Fact], for each logical assertion you want to make.
* The assertion should first call Then, which executes the test and returns the result.
* You can for instance test if a certain value was returned by writing `Then.Result.Is([SomeValue])`.
 
Example:
```
namespace MyProject.Test.Calculator;

public abstract class WhenAddTwoNumbers : TestStatic<int>
{
    protected int X, Y;
    protected WhenAddTwoNumbers() => When(() => MyProject.Calculator.AddTwoNumbers(X, Y);

    public class Given_1_And_2 : WhenAddTwoNumbers
    {
        protected override void Given() => (X, Y) = (1, 2);
        [Fact] public void ThenReturn_3() => Then.Result.Is(3);
    }
}
```

### Test a static void method
* To test a static void method `[MyClass.MyMethod]`, Create a new abstract class named `When[MyMethod]` inheriting `WhenGivenThen.TestStatic<object>`. 
(The generic parameter has no impact, but object is used by convention)
* Create a protected parameterless constructor that calls `When` with a lambda expression calling the method to test: `When(() => [MyClass].[MyMethod]([Args...]))`.
* Each argument has to be defined as a protected field at the top of the class.

* For each set of preconditions you want to test, Create a nested class within the When-class with the name `Given[SomePrecondition]` inheriting the outer class.
* Override the method `Given` to assign values to the arguments of the method-to-test
 
* Finally, create a test method, attributed with [Fact], for each logical assertion you want to make.
* The assertion should first call Then, which executes the test and returns the result.
* You can for instance test if an error was thrown by writing `Then.throws<[SomeException]>()`.
 
Example:
```
namespace MyProject.Test.Validator;

public abstract class WhenVerifyAreEqual : TestStatic<object>
{
    protected int X, Y;
    protected WhenVerifyAreEqual() => When(() => MyProject.Validator.VerifyAreEqual(X, Y);

    public class Given_1_And_2 : WhenVerifyAreEqual
    {
        protected override void Given() => (X, Y) = (1, 2);
        [Fact] public void ThenThrows_NotEqual() => Then.Throws<NotEqual>();
    }

    public class Given_2_And_2 : WhenVerifyAreEqual
    {
        protected override void Given() => (X, Y) = (2, 2);
        [Fact] public void ThenDoNotThrow() => Then.NotThrows();
    }
}
```

More examples can be found as Unit tests in the source code
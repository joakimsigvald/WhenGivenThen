# Unit test When (invoke method) Given (input/preconditions) Then (Expected result)

All-inclusive framework for writing and running automated tests in Visual Studio, 
based on the popular "Given-When-Then" pattern. Built upon XUnit and Moq, referencing Test SDK and runner, and including a fluent assertion framework.

Whether you are beginner or expert in unit-testing, this framework will help you write more descriptive tests with less code.

## For beginner level users

### Test a static void method
* To test a static void method `[MyClass.MyMethod]`, Create a new abstract class named `When[MyMethod]` inheriting `WhenGivenThen.TestStatic<object>`.
* Override the method `Action` and return a call to the method-to-test as a lambda expression: `Action => () => [MyClass].[MyMethod]([Args...])`.
* Each argument has to be defined as a protected field at the top of the class.

* For each set of preconditions you want to test, Create a nested class within the When-class with the name `Given[SomePrecondition]` inheriting the outer class.
* Override the method `Given` to assign values to the arguments to the method-to-test (the preconditions)
 
* Finally, create a test method, attributed with [Fact], for each logical assertion you want to make.
* The assertion should first call Then, which executes the test and returns the result.
* You can for instance test if an error was thrown by writing `Then.Throws<[SomeException]>`

### Test a static function with return value
* To test a static method `[MyClass.MyMethod]` returning `[ReturnType]`, Create a new abstract class named `When[MyMethod]` inheriting `WhenGivenThen.TestStatic<[ReturnType]>`.
* Override the method `Func` and return a call to the method-to-test as a lambda expression: `Func => () => [MyClass].[MyMethod]([Args...])`.
* Each argument has to be defined as a protected field at the top of the class.

* For each set of preconditions you want to test, Create a nested class within the When-class with the name `Given[SomePrecondition]` inheriting the outer class.
* Override the method `Given` to assign values to the arguments to the method-to-test
 
* Finally, create a test method, attributed with [Fact], for each logical assertion you want to make.
* The assertion should first call Then, which executes the test and returns the result.
* You can for instance test if a certain value was returned by writing `Then.Result.Is([SomeValue])`.

## For intermediate level users

For each class under test (SUT = Subject under test), 
create a folder with the same subfolders and name: "[Subfolders../ClassName]" in your test project (named "[ProductionFolder].Test")
Then create an abstract class in the new folder, named "Test[ClassName]", that inherits one of the four base classes (TestSubject, TestSubjectAsync, TestStatic, TestStaticAsync).
Then create an abstract class in the same folder for each public method to test, named "When[MethodName]", that inherits "Test[ClassName]".
Then, for each condition to be tested, create a nested class, named "Given[TheCondition]", within the When-class.
Finally, the Given-class will have one or more test-methods for each logical assert, named "Then[ExpectedOutcome]".
Necessary precondition is put in the same nested class inside the overridden method "Given" and necessary setup is put in the overridden method "Setup".
It is also possible to add tear-down logic in the same class by overriding the method "TearDown".

Important: the method to be tested is call by calling the method "Act" and the setup is performed by calling the method "Arrange". For convenience,
there is a method called "ArrangeAndAct" that do both in order. It is recommended to call "ArrangeAndAct" in the constructor of the base class, 
and only use [Fact] attribute for test methods not [Theory], since that force you to put all steps (arrange, act, assert) in the test method,
which goes against the pattern that this package supports.

Example:
```
namespace MyCompany.MyApplication.MyProject.Test.MyFolder.MyClass
{
    public abstract class TestMyClass<TResult> : TestSubjectAsync<MyProject.MyFolder.MyClass, TResult>
    {
        protected override Subjects.AsyncShoppingService CreateSUT() => new(MockOf<ISomeService>());

        public TestMyClass() => ArrangeAndAct();
    }

    public abstract class WhenMyMethod : TestMyClass<SomeResult>
    {
        protected int SomeInput;
        protected override Func<Task<SomeResult>> Func => () => SUT.MyMethod(Id);

        public class GivenSomePrecondition : WhenMyMethod
        {
            protected override void Given() => SomeInput = 123;
            [Fact] public void ThenSomeExpectation() => Assert.Equal(456, Result);
        }
    }
}
```

## For expert level users

More examples can be found as Unit tests in the source code

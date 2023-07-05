# Unit test When (invoke method) Given (input/preconditions) Then (Expected result)

Framework for writing and running automated tests in .Net in a flexible and fluent style, 
based on the popular "Given-When-Then" pattern, built upon XUnit and Moq.

Whether you are beginner or expert in unit-testing, this framework will help you to write more descriptive tests with less code.

## Usage

It is assumed that you are already familiar with Xunit and Moq, or similar test and mocking frameworks.

### Test a static method with [Theory]

If you are used to writing one test class per production class and use Theory for test input, you can use a similar style to write minimalistic tests with a minimum of clutter.
First you create a test pipeline by calling `When` with a lambda expression to test.
Then you can verify the result by calling `Then` on the returned pipeline and check the result with `Is`

Example:
```
public class TestCalculator : TestStatic<int>
{
    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(3, 4, 7)]
    public void WhenAddThenReturnSum(int x, int y, int sum)
        => When(() => Calculator.Add(x, y)).Then.Result.Is(sum);

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(3, 4, 12)]
    public void WhenMultiplyThenReturnProduct(int x, int y, int product)
        => When(() => Calculator.Multiply(x, y)).Then.Result.Is(product);
}
```

### Test a static method with [Fact]

* For more complex and realistic scenarious, it is recommended to create tests in a separate project from the production code, named [MyProject].Test
* The test-project should mimmic the production project's folder structure, but in addition have one folder for each class to test. 
* Within that folder, create one test-class per method to test.

* To test a static method `[MyClass].[MyMethod]` returning `[ReturnType]`, Create a new abstract class named `When[MyMethod]` inheriting `TestStatic<[ReturnType]>`.
* Create a parameterless constructor that calls `When` with a lambda expression calling the method to test: `When(() => [MyClass].[MyMethod]([Args...]))`.
* Each argument should be defined as a protected field at the top of the class.

* For each set of preconditions you want to test, Create a nested class within the When-class with the name `Given[SomePrecondition]` inheriting the outer class.
* Call the method `Given` to assign values to the arguments of the method-to-test.
* Finally, create a test method, attributed with [Fact], for each logical assertion you want to make.
* The assertion should first call Then, which executes the test and returns the result.
* If there is only one test method in the Given-class, the call to `Given` can be placed in the chain before `Then`
* You can for instance test if a certain value was returned by writing `Then.Result.Is([SomeValue])`.
 
Example:
```
namespace MyProject.Test.Calculator;

public abstract class WhenAddTwoNumbers : TestStatic<int>
{
    protected int X, Y;
    public WhenAddTwoNumbers() => When(() => MyProject.Calculator.Add(X, Y);

    public class Given_1_And_1 : WhenAdd
    {
        [Fact] public void ThenReturn_3() => Given(() => (X, Y) = (1, 2)).Then.Result.Is(3);
    }

    public class Given_3_And_4 : WhenAdd
    {
        [Fact] public void ThenReturn_7() => Given(() => (X, Y) = (3, 4)).Then.Result.Is(7);
    }
}
```

### Test a static void method
* When testing a static void method, there is no return value to verify in result and by convention the generic TResult parameter is set to object.
* However you can us `Throws` to verify exceptions thrown.
 
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

### Test an instance method with dependencies
* To test an instance method `[MyClass].[MyMethod]` returning `[ReturnType]`, Create a new abstract class named `Test[MyClass]<TResult>` inheriting `WhenGivenThen.TestSubject<[MyClass], TResult>`.
* Override the method CreateSUT and return a new instance of the class to test.
* Then create an abstract class named `When[MyMethod]` inheriting `Test[MyClass]` in the same way as for static methods.

* For each set of preconditions you want to test, Create a nested class within the When-class with the name `Given[SomePrecondition]` inheriting the outer class.
* If the class constructor has any dependencies that you want to mock, reference the mocked instances by `The<MyMockedInterface>()` when creating the instance.
* Call `Given` with a lambda implementing the mocking. Use Moq framework to mock behavour.
* `Given` can be called several times and works as a stack: Each setup provided through `Given` will be applied in the opposite order that they were given.
* So if you want to foirst assign a variable and then use that variable for mocking, the variable assignment lambda should be provided after the mocking lambda.
 
* In the test method, you can verify that a dependency has been called by writing `Then.The<MyMockedInterface>([SomeLambdaExpression])`. Again, Moq framework is used to express behaviour to verify.
 
Example:
```
namespace MyProject.Test.ShoppingService;

public abstract class TestShoppingService<TResult> : TestSubject<MyProject.ShoppingService, TResult>
{
    protected override Subjects.ShoppingService CreateSUT() => new(The<IOrderService>());
}

public abstract class WhenPlaceOrder : TestShoppingService<object>
{
    protected ShoppingCart Cart;

    protected WhenPlaceOrder() => When(() => SUT.PlaceOrder(Cart));

    public class GivenCart : WhenPlaceOrder
    {
        [Fact] public void ThenOrderIsCreated() 
            => Given(() => Cart = new()).Then.The<IOrderService>(_ => _.CreateOrder(Cart));
    }
}
```

### Test async methods

All the examples above also works for async methods, with small modifications.

More examples can be found as Unit tests in the source code.
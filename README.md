# b2l-test

Utility for creating unit tests and other automated tests

Usage:
For each class under test (SUT = Subject under test), create a folder named "[ClassName]" in your test project (named "[ProductionFolder].Test")
Create a class in the folder named "[ClassName]TestBase", that inherits TestBase (with class as generic type, or non-generic if class is static)
Create a generic class with same name with a protected property named "ReturnValue" and the generic argument as type.
For each member in SUT to be tested, create an abstract class named "When[MemberName]", that inherits "[ClassName]TestBase" (generic if has return type or non-generic if void)
For each condition to be tested, create a public test class inside the When-class that inherit the When-class, named "Given[TheCondition]"
Example:

//File #1 - base class for one particular class
namespace MyCompany.MyApplication.MyProject.Test.MyClass
{
    public abstract class MyClassTestBase : TestBase<MyProject.MyClass>
    {
        //protected properties to use for setup/instantiation here

        protected override MyProject.MyClass CreateSUT()
            => new MyProject.MyClass()
            {
                //instantiation here
            };
    }

    public abstract class TestMyClass<TReturn> : MyClassTestBase
    {
        protected TReturn ReturnValue;
    }
}

//File #2 - base class and test classes for one particular method
namespace MyCompany.MyApplication.MyProject.Test.MyClass
{
    public abstract class WhenMyMethod : TestMyClass<MyReturnValue>
    {
        // protected properties to use as arguments here

        protected override void Act() => ReturnValue = SUT.MyMethod(//arguments here);

        public class GivenSomeCondition : WhenMyMethod
        {
            public GivenSomeCondition() {
                //Set test-data here...
            }

            protected override void Given() { 
                //...or here            
            }

            [Fact]
            public void ThenExpectedOutcome()
            {
                //...or here            
                ArrangeAndAct();
                //Asserts here
            }
        }

        public class GivenAnotherCondition : WhenMyMethod
        {
            [Theory]
            [InlineData(//test data here)]
            public void ThenExpectedOutcome(//test data here)
            {
                //Set test-data here
                ArrangeAndAct();
                //Asserts here
            }
        }
    }
}

//File #3 - base class and test classes for another method with return type void
namespace MyCompany.MyApplication.MyProject.Test.MyClass
{
    public abstract class WhenMyAction : TestMyClass
    {
        // protected properties to use as arguments here

        protected override void Act() => SUT.MyAction(//arguments here);

        public class GivenSomeCondition : WhenMyAction
        {
            [Fact]
            public void ThenExpectedOutcome()
            {
                //Set test-data here
                ArrangeAndAct();
                //Asserts here
            }
        }
    }
}
# Unit test When (invoke method) Given (input/preconditions) Then (Expected result)

Utility for creating unit tests and other automated tests

Usage:
For each class under test (SUT = Subject under test), 
create a folder with the same subfolders and name: "[Subfolders../ClassName]" in your test project (named "[ProductionFolder].Test")
Then create an abstract class in the new folder, named "Test[ClassName]", that inherits one of the four base classes (TestSubject, TestSubjectAsync, TestStatic, TestStaticAsync).
Then create an abstract class in the same folder for each public method to test, named "When[MethodName]", that inherits "Test[ClassName]".
Then, for each condition to be tested, create a nested class, named "Given[TheCondition]", within the When-class.
Finally, the Given-class will have one or more test-methods for each locical assert, named "Then[ExpectedOutcom]".
Necessary precondition is put in the same nested class inside the overridden method "Given" and necessary setup is put in the overridden method "Setup".
It is also possible to add tear-down logic in the same class by overriding the method "TearDown".

Important: the method to be tested is call by calling the method "Act" and the setup is performed by calling the method "Arrange". For convenience,
there is a method called "ArrangeAndAct" that do both in order. It is recommended to call "ArrangeAndAct" in the constructor of the base class, 
and only use [Fact] attribute for test methods not [Theory], since that force you to put all steps (arrange, act, assert) in the test method,
which goes against the pattern that this package supports.

Example:

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

More examples can be found as Unit tests in the source code

using Moq;

namespace WhenGivenThen.Verification;

public interface IMocked
{
    Mock<TObject> GetMock<TObject>() where TObject : class;
}
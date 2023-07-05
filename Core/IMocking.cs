using Moq;
namespace WhenGivenThen;

public interface IMocking
{
    Mock<TObject> GetMock<TObject>() where TObject : class;
}
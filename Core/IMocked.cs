using Moq;
namespace WhenGivenThen;

public interface IMocked
{
    Mock<TObject> GetMock<TObject>() where TObject : class;
}
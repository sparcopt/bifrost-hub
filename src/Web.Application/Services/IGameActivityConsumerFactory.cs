namespace Web.Application.Services;

public interface IGameActivityConsumerFactory
{
    IGameActivityConsumer Create(string name);
}
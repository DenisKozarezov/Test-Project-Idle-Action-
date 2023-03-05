namespace Core.Services
{
    public interface IRegisterService<TService>
    {
        TService Register(int key, TService obj);
        void Unregister(int key);
        TService Take(int key);
    }
}
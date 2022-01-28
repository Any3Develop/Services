using Services.StorageService;

namespace Services.StateMachine
{
    public interface IState : IStorageItem
    {
        void OnEnter(params object[] args);
        void OnExit();
    }
}
using System;

namespace Services.BootstrapService
{
    public interface ICommand
    {
        event EventHandler Done;
        void Do();
    }
}
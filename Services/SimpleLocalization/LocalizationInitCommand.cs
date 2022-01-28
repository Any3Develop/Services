using System;
using Services.BootstrapService;

namespace Services.SimpleLocalization
{
    public class LocalizationInitCommand : Command
    {
        public override void Do()
        {
            LocalizationManager.Read();
            LocalizationManager.Language = "Russian";
            OnDone();
        }
    }
}
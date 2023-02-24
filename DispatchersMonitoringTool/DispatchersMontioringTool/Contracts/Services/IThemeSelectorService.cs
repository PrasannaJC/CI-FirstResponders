using System;

using DispatchersMontioringTool.Models;

namespace DispatchersMontioringTool.Contracts.Services
{
    public interface IThemeSelectorService
    {
        void InitializeTheme();

        void SetTheme(AppTheme theme);

        AppTheme GetCurrentTheme();
    }
}

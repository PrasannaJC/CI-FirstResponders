﻿using DispatchersMonitoringTool.Models;

namespace DispatchersMonitoringTool.Contracts.Services;

public interface IThemeSelectorService
{
    void InitializeTheme();

    void SetTheme(AppTheme theme);

    AppTheme GetCurrentTheme();
}

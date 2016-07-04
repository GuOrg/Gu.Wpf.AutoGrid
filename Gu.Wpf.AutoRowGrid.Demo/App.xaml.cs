﻿namespace Gu.Wpf.AutoRowGrid.Demo
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args.Length == 1)
            {
                var window = e.Args[0];
                this.StartupUri = new Uri($"UiTestWindows/{window}.xaml", UriKind.Relative);
            }

            base.OnStartup(e);
        }
    }
}

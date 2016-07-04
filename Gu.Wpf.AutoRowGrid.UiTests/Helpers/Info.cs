﻿namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    public static class Info
    {
        public static ProcessStartInfo ProcessStartInfo { get; } = CreateStartInfo(null);

        internal static ProcessStartInfo CreateStartInfo(string args)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = GetExeFileName(),
                Arguments = args,
                UseShellExecute = false,
                //CreateNoWindow = false,
                //RedirectStandardOutput = true,
                //RedirectStandardError = true
            };
            return processStartInfo;
        }

        private static string GetExeFileName()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var testDirestory = Path.GetDirectoryName(new Uri(assembly.CodeBase).AbsolutePath);
            var assemblyName = assembly.GetName().Name;
            var exeDirectoryName = assemblyName.Replace("UiTests", "Demo");
            var exeDirectory = testDirestory.Replace(assemblyName, exeDirectoryName);
            var fileName = Path.Combine(exeDirectory, "Gu.Wpf.AutoRowGrid.Demo.exe");

            return fileName;
        }
    }
}

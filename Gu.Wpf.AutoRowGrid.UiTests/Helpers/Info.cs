namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using System;
    using System.IO;
    using System.Reflection;

    public static class Info
    {
        public static string ExeFileName { get; } = GetExeFileName();

        private static string GetExeFileName()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var testDirestory = Path.GetDirectoryName(new Uri(assembly.CodeBase).AbsolutePath);
            var assemblyName = assembly.GetName().Name;
            var exeDirectoryName = assemblyName.Replace("UiTests", "Demo");
            // ReSharper disable once PossibleNullReferenceException
            var exeDirectory = testDirestory.Replace(assemblyName, exeDirectoryName);
            var fileName = Path.Combine(exeDirectory, "Gu.Wpf.AutoRowGrid.Demo.exe");

            return fileName;
        }
    }
}

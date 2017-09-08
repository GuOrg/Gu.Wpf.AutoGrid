﻿namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class ExplicitRowsAndColumnsTests
    {
        private static readonly string WindowName = "ExplicitRowsAndColumnsWindow";

        [Test]
        public void Bounds()
        {
            using (var app = Application.Launch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual("0,0 35,18", window.GetItemPosition("R0C0"));
                Assert.AreEqual("35,0 150,18", window.GetItemPosition("R0C1"));
                Assert.AreEqual("0,18 35,36", window.GetItemPosition("R1C0"));
                Assert.AreEqual("35,18 150,36", window.GetItemPosition("R1C1"));
            }
        }
    }
}
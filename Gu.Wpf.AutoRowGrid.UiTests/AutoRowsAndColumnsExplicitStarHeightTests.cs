namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class AutoRowsAndColumnsExplicitStarHeightTests
    {
        private static readonly string WindowName = "AutoRowsAndColumnsExplicitStarHeightWindow";

        [Test]
        public void Bounds()
        {
            using (var app = Application.Launch("Gu.Wpf.AutoRowGrid.Demo.exe", WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual("0,0 35,100", window.GetItemPosition("R0C0"));
                Assert.AreEqual("35,0 150,100", window.GetItemPosition("R0C1"));
                Assert.AreEqual("0,100 35,200", window.GetItemPosition("R1C0"));
                Assert.AreEqual("35,100 150,200", window.GetItemPosition("R1C1"));
            }
        }
    }
}
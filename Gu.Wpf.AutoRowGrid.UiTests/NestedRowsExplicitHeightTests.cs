namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class NestedRowsExplicitHeightTests
    {
        private static readonly string WindowName = "NestedRowsExplicitHeightWindow";

        [Test]
        public void Bounds()
        {
            using (var app = Application.Launch(Info.ExeFileName, WindowName))
            {
                var window = app.MainWindow;
                Assert.AreEqual("0,0 35,25", window.GetItemPosition("R0C0"));
                Assert.AreEqual("35,0 150,25", window.GetItemPosition("R0C1"));
                Assert.AreEqual("0,25 35,50", window.GetItemPosition("R1C0"));
                Assert.AreEqual("35,25 150,50", window.GetItemPosition("R1C1"));
                Assert.AreEqual("0,50 35,80", window.GetItemPosition("R2C0"));
                Assert.AreEqual("35,50 150,80", window.GetItemPosition("R2C1"));
                Assert.AreEqual("0,80 35,110", window.GetItemPosition("R3C0"));
                Assert.AreEqual("35,80 150,110", window.GetItemPosition("R3C1"));
            }
        }
    }
}
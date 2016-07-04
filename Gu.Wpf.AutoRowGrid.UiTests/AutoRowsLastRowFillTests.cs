namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class AutoRowsLastRowFillTests : WindowTest
    {
        public override string Title { get; } = "AutoRowsLastRowFillWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 35,18", this.Window.GetItemPosition("R0C0"));
            Assert.AreEqual("35,0 150,18", this.Window.GetItemPosition("R0C1"));
            Assert.AreEqual("0,18 35,200", this.Window.GetItemPosition("R1C0"));
            Assert.AreEqual("35,18 150,200", this.Window.GetItemPosition("R1C1"));
        }
    }
}
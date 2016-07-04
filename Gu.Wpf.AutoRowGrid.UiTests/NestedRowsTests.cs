namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class NestedRowsTests : WindowTest
    {
        public override string Title { get; } = "NestedRowsWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 35,18", this.Window.GetItemPosition("R0C0"));
            Assert.AreEqual("35,0 150,18", this.Window.GetItemPosition("R0C1"));
            Assert.AreEqual("0,18 35,36", this.Window.GetItemPosition("R1C0"));
            Assert.AreEqual("35,18 150,36", this.Window.GetItemPosition("R1C1"));
            Assert.AreEqual("0,36 35,54", this.Window.GetItemPosition("R2C0"));
            Assert.AreEqual("35,36 150,54", this.Window.GetItemPosition("R2C1"));
            Assert.AreEqual("0,54 35,72", this.Window.GetItemPosition("R3C0"));
            Assert.AreEqual("35,54 150,72", this.Window.GetItemPosition("R3C1"));
        }
    }
}
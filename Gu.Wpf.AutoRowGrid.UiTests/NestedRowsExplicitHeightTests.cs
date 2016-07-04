namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class NestedRowsExplicitHeightTests : WindowTest
    {
        public override string Title { get; } = "NestedRowsExplicitHeightWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 35,25", this.Window.GetItemPosition("R0C0"));
            Assert.AreEqual("35,0 150,25", this.Window.GetItemPosition("R0C1"));
            Assert.AreEqual("0,25 35,50", this.Window.GetItemPosition("R1C0"));
            Assert.AreEqual("35,25 150,50", this.Window.GetItemPosition("R1C1"));
            Assert.AreEqual("0,50 35,80", this.Window.GetItemPosition("R2C0"));
            Assert.AreEqual("35,50 150,80", this.Window.GetItemPosition("R2C1"));
            Assert.AreEqual("0,80 35,110", this.Window.GetItemPosition("R3C0"));
            Assert.AreEqual("35,80 150,110", this.Window.GetItemPosition("R3C1"));
        }
    }
}
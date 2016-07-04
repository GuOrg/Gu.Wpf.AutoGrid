namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class AutoRowsAndColumnsTests : WindowTest
    {
        public override string Title { get; } = "AutoRowsAndColumnsWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 35,18", this.Window.GetItemPosition("R0C0"));
            Assert.AreEqual("35,0 150,18", this.Window.GetItemPosition("R0C1"));
            Assert.AreEqual("0,18 35,36", this.Window.GetItemPosition("R1C0"));
            Assert.AreEqual("35,18 150,36", this.Window.GetItemPosition("R1C1"));
        }
    }
}
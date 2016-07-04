namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class AutoRowsAndColumnsExplicitHeightTests : WindowTest
    {
        public override string Title { get; } = "AutoRowsAndColumnsExplicitHeightWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 35,100", this.Window.GetItemPosition("R0C0"));
            Assert.AreEqual("35,0 150,100", this.Window.GetItemPosition("R0C1"));
            Assert.AreEqual("0,100 35,200", this.Window.GetItemPosition("R1C0"));
            Assert.AreEqual("35,100 150,200", this.Window.GetItemPosition("R1C1"));
        }
    }
}
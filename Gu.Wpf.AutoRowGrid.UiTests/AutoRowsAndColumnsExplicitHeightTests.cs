namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class AutoRowsAndColumnsExplicitHeightTests : WindowTest
    {
        public override string Title { get; } = "AutoRowsAndColumnsExplicitHeightWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 31,100", this.Window.GetTextBoxPosition("R0C0"));
            Assert.AreEqual("31,0 150,100", this.Window.GetTextBoxPosition("R0C1"));
            Assert.AreEqual("0,100 31,200", this.Window.GetTextBoxPosition("R1C0"));
            Assert.AreEqual("31,100 150,200", this.Window.GetTextBoxPosition("R1C1"));
        }
    }
}
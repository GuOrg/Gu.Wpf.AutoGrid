namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class AutoRowsAndColumnsExplicitHeightTests : WindowTest
    {
        public override string Title { get; } = "AutoRowsAndColumnsExplicitHeightWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 27,100", this.Window.GetTextBoxPosition("R0C0"));
            Assert.AreEqual("27,0 150,100", this.Window.GetTextBoxPosition("R0C1"));
            Assert.AreEqual("0,100 27,200", this.Window.GetTextBoxPosition("R1C0"));
            Assert.AreEqual("27,100 150,200", this.Window.GetTextBoxPosition("R1C1"));
        }
    }
}
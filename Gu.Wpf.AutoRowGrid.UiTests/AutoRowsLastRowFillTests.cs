namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class AutoRowsLastRowFillTests : WindowTest
    {
        public override string Title { get; } = "AutoRowsLastRowFillWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 34,22", this.Window.GetTextBoxPosition("R0C0"));
            Assert.AreEqual("34,0 150,22", this.Window.GetTextBoxPosition("R0C1"));
            Assert.AreEqual("0,22 34,200", this.Window.GetTextBoxPosition("R1C0"));
            Assert.AreEqual("34,22 150,200", this.Window.GetTextBoxPosition("R1C1"));
        }
    }
}
namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class ExplicitRowsAndColumnsLastRowFillTests : WindowTest
    {
        public override string Title { get; } = "ExplicitRowsAndColumnsLastRowWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 29,18", this.Window.GetTextBoxPosition("R0C0"));
            Assert.AreEqual("29,0 150,18", this.Window.GetTextBoxPosition("R0C1"));
            Assert.AreEqual("0,18 29,200", this.Window.GetTextBoxPosition("R1C0"));
            Assert.AreEqual("29,18 150,200", this.Window.GetTextBoxPosition("R1C1"));
        }
    }
}
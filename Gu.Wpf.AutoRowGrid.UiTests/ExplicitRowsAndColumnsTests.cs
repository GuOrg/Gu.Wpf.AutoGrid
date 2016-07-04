namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class ExplicitRowsAndColumnsTests : WindowTest
    {
        public override string Title { get; } = "ExplicitRowsAndColumnsWindow";
        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 34,22", this.Window.GetTextBoxPosition("R0C0"));
            Assert.AreEqual("34,0 150,22", this.Window.GetTextBoxPosition("R0C1"));
            Assert.AreEqual("0,22 34,44", this.Window.GetTextBoxPosition("R1C0"));
            Assert.AreEqual("34,22 150,44", this.Window.GetTextBoxPosition("R1C1"));
        }
    }
}
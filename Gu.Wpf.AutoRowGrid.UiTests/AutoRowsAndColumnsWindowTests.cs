namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using NUnit.Framework;

    public class AutoRowsAndColumnsTests : WindowTest
    {
        public override string Title { get; } = "AutoRowsAndColumnsWindow";

        [Test]
        public void Bounds()
        {
            Assert.AreEqual("0,0 33,20", this.Window.GetTextBoxPosition("R0C0"));
            Assert.AreEqual("33,0 150,20", this.Window.GetTextBoxPosition("R0C1"));
            Assert.AreEqual("0,20 33,40", this.Window.GetTextBoxPosition("R1C0"));
            Assert.AreEqual("33,20 150,40", this.Window.GetTextBoxPosition("R1C1"));
        }
    }
}
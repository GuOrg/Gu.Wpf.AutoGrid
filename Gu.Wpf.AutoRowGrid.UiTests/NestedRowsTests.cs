namespace Gu.Wpf.AutoRowGrid.UiTests;

using Gu.Wpf.UiAutomation;
using NUnit.Framework;

public class NestedRowsTests
{
    private const string WindowName = "NestedRowsWindow";

    [Test]
    public void Bounds()
    {
        using var app = Application.Launch("Gu.Wpf.AutoRowGrid.Demo.exe", WindowName);
        var window = app.MainWindow;
        Assert.AreEqual("0,0 35,18", window.GetItemPosition("R0C0"));
        Assert.AreEqual("35,0 150,18", window.GetItemPosition("R0C1"));
        Assert.AreEqual("0,18 35,36", window.GetItemPosition("R1C0"));
        Assert.AreEqual("35,18 150,36", window.GetItemPosition("R1C1"));
        Assert.AreEqual("0,36 35,54", window.GetItemPosition("R2C0"));
        Assert.AreEqual("35,36 150,54", window.GetItemPosition("R2C1"));
        Assert.AreEqual("0,54 35,72", window.GetItemPosition("R3C0"));
        Assert.AreEqual("35,54 150,72", window.GetItemPosition("R3C1"));
    }
}

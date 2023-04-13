namespace Gu.Wpf.AutoRowGrid.UiTests;

using Gu.Wpf.UiAutomation;
using NUnit.Framework;

public class AutoRowsLastRowFillTests
{
    private const string WindowName = "AutoRowsLastRowFillWindow";

    [Test]
    public void Bounds()
    {
        using var app = Application.Launch("Gu.Wpf.AutoRowGrid.Demo.exe", WindowName);
        var window = app.MainWindow;
        Assert.AreEqual("0,0 35,18", window.GetItemPosition("R0C0"));
        Assert.AreEqual("35,0 150,18", window.GetItemPosition("R0C1"));
        Assert.AreEqual("0,18 35,200", window.GetItemPosition("R1C0"));
        Assert.AreEqual("35,18 150,200", window.GetItemPosition("R1C1"));
    }
}

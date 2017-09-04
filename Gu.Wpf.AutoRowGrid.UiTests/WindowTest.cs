namespace Gu.Wpf.AutoRowGrid.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public abstract class WindowTest
    {
        private Application application;

        protected Window Window { get; private set; }

        public abstract string Title { get; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.application = Application.Launch(Info.ExeFileName, this.Title);
            this.Window = this.application.MainWindow;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }
    }
}
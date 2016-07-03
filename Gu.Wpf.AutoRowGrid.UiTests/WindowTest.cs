using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace Gu.Wpf.AutoRowGrid.UiTests
{
    public abstract class WindowTest
    {
        private Application application;
        protected Window Window { get; private set; }

        public abstract string Title { get; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var processStartInfo = Info.CreateStartInfo(Title);
            this.application = Application.AttachOrLaunch(processStartInfo);
            this.Window = this.application.GetWindow(Title);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.application?.Dispose();
        }
    }
}
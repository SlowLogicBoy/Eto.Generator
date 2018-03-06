using Eto.Forms;
using Moq;

namespace Eto.Generator.Tests.Helpers
{
    public class EtoTestPlatform : Platform
    {
        public override string ID => "Eto.Test";

        public EtoTestPlatform()
        {
            this.Add<Application.IHandler>(() => new Mock<Application.IHandler>().Object);
            this.Add<TextBoxCell.IHandler>(() => new Mock<TextBoxCell.IHandler>().Object);
        }
    }
}
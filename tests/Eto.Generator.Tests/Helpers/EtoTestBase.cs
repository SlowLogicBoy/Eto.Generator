using Eto.Forms;

namespace Eto.Generator.Tests.Helpers
{
    public class EtoTestBase
    {
        protected Application Application { get; }
        public EtoTestBase()
        {
            Application = new Application(new EtoTestPlatform());
        }
    }
}
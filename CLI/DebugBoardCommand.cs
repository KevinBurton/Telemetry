using System.Reflection;

namespace CLI
{
    public class DebugBoardCommand : CommandBase
    {
        protected override MethodInfo[] Methods { get; set; }

        public DebugBoardCommand()
        {
            Methods = typeof(DebugBoardCommand).GetMethods();
        }
    }
}

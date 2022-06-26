using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public static class Helper
    {
        public static (bool Result, string Name) GetControllerName(string controller)
        {
            if (!controller.EndsWith("Controller"))
            {
                return (false, null);
            }

            int lastDot = controller.LastIndexOf('.') + 1;
            int length = controller.Length - (lastDot + 10);

            string name = controller.Substring(lastDot, length);

            return (true, name);
        }
    }
}

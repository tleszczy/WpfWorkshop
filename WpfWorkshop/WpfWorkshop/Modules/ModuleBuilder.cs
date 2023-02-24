using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfWorkshop.Modules
{
    public class ModuleBuilder
    {
        public ModuleBuilder(IEnumerable<Func<ICustomModule>> modules)
        {
            int counter = 0;
            var funcs = modules as IList<Func<ICustomModule>> ?? modules.ToList();
            foreach (var func in funcs.Reverse())
            {
                try
                {
                    var module = func();
                    counter++;
                }
                catch (Exception e)
                {
                }
            }
        }
    }
}

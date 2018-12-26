using System;
using System.Collections.Generic;
using System.Text;

namespace Sdl.Base.Orm
{
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }
    }
}

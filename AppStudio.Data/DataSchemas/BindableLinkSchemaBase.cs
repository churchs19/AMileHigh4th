using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudio.Data.DataSchemas
{
    public abstract class BindableLinkSchemaBase : BindableSchemaBase
    {
        public abstract string DefaultLink { get; }

        public string IAmGoing { get { return "I'm going to " + DefaultTitle; } }
    }
}

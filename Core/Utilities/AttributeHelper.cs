using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotDbGeneratedAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
    }
}

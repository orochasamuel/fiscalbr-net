using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalBr.Common.Sped
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SpedIgnorarAttribute : Attribute
    {
        public SpedIgnorarAttribute()
        {

        }
    }
}

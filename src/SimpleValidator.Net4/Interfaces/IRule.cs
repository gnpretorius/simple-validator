using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleValidator.Interfaces
{
    public interface IRule
    {
        bool IsValid();
    }
}

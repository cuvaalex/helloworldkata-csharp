using Rolex.DevSecOps.Lab.HelloWorld.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.Common.Guards;

public static class Guard
{
    public static void Against(this Func<bool> func, string message)
    {
        if (func())
        {
            throw new ValidationException(message);
        }
    }
}
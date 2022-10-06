﻿using Rolex.DevSecOps.Lab.HelloWorld.Core.Exceptions;

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
namespace Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.Common.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StringGuardExtensions
{
    public static string GuardAgainstNullOrWhiteSpace(this string? value, string message)
    {
        Guard.Against(() => string.IsNullOrWhiteSpace(value), message);
        return value;
    }
}
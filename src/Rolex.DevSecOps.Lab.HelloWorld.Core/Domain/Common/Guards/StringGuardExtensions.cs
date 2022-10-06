﻿namespace Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.Common.Guards;


public static class StringGuardExtensions
{
    public static string GuardAgainstNullOrWhiteSpace(this string? value, string message)
    {
        Guard.Against(() => string.IsNullOrWhiteSpace(value), message);
        return value;
    }
}
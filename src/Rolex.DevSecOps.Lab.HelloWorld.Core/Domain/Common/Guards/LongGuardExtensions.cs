namespace Rolex.DevSecOps.Lab.HelloWorld.Core.Domain.Common.Guards;

public static class LongGuardExtensions
{
    public static long GuardAgainstSmallerThan0(this long value, string message)
    {
        Guard.Against(() => value <= 0, message);
        return value;
    }
}
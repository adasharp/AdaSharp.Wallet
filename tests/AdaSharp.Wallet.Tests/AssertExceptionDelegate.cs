using System;

namespace AdaSharp.Tests
{
    public delegate void AssertExceptionDelegate<in T>(T caughtException) where T : Exception;
}
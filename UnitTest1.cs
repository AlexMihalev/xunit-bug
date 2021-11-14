using System.Collections.Generic;
using Xunit;

namespace xunit_bug;

public class UnitTest1
{
    public static IEnumerable<object[]> ValuesWithDecimal() 
    {
        yield return new object[] { (decimal)42 };
    }

    public static IEnumerable<object[]> ValuesWithoutDecimal() 
    {
        yield return new object[] { (long)42 };
        yield return new object[] { (ulong)42 };
        yield return new object[] { (double)42 };
    }

    [Theory]
    [MemberData(nameof(ValuesWithDecimal))]
    public void Fails<T>(T value) => Assert.NotNull(value);

    [Theory]
    [MemberData(nameof(ValuesWithoutDecimal))]
    public void Pass<T>(T value) => Assert.NotNull(value);
}
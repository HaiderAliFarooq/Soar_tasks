namespace JuiceShopAutomation.Maps.Common;

/// <summary>
/// Custom assert handler methods.
/// </summary>
public static class AssertHandler
{
    //
    // Summary:
    //     Assert based on Equals using StringComparison.Ordinal. Actual value must be matched
    //     with expected value.
    //
    // Parameters:
    //   actual:
    //     Provide the actual value.
    //
    //   expected:
    //     Provide the expected value.
    public static void AssertEquals(string actual, string expected)
    {
        if (!actual.Equals(expected, StringComparison.Ordinal) && !expected.ToLower(System.Globalization.CultureInfo.CurrentCulture).Equals("#skip") && !actual.ToLower(System.Globalization.CultureInfo.CurrentCulture).Equals("#skip"))
        {
            throw new InvalidOperationException("[Actual]: " + actual + " \n [Expected]: " + expected);
        }
    }

    //
    // Summary:
    //     Assert based on the provided bool condition. False will throw exception.
    //
    // Parameters:
    //   condition:
    //     Provide the condition.
    //
    //   message:
    //     Message that will be used for throw exception.
    public static void AssertTrue(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    //
    // Summary:
    //     Assert based on the provided bool condition. True will throw exception.
    //
    // Parameters:
    //   condition:
    //     Provide the condition.
    //
    //   message:
    //     Message that will be used for throw exception.
    public static void AssertFalse(bool condition, string message)
    {
        if (condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    //
    // Summary:
    //     Assert based on Contains using StringComparison.OrdinalIgnoreCase. Actual must
    //     contain expected value.
    //
    // Parameters:
    //   actual:
    //     Provide the actual value.
    //
    //   expected:
    //     Provide the expected value.
    public static void AssertContains(string actual, string expected)
    {
        if (!actual.Contains(expected, StringComparison.OrdinalIgnoreCase) && !expected.Equals("#skip", StringComparison.OrdinalIgnoreCase) && !actual.Equals("#skip", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("[Actual]: " + actual + " \n [Expected]: " + expected);
        }
    }
}

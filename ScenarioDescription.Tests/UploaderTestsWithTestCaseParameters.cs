using FluentAssertions;
using NUnit.Framework.Internal;

namespace ScenarioDescription.Tests;

public class UploaderTestsWithTestCaseParameters
{
    public static class Data
    {
        public static IEnumerable<TestCaseParameters> WithInvalidSkus => new[]
        {
            new TestCaseData(new List<string> { "invalid" }).SetName("One invalid value"),
            new TestCaseData(new List<string> { "valid", "invalid" }).SetName("One valid, one invalid value"),
            new TestCaseData(new List<string> { "invalid", "valid", "invalid" })
        };
    }
    
    [TestCaseSource(typeof(Data), nameof(Data.WithInvalidSkus))]
    [Description("With invalid skus")]
    public void Upload_works(IReadOnlyList<string> skus)
    {
        // Arrange

        // Act

        // Assert
        // Deliberately fail so we see something in dotnet test output
        skus.Should().NotContain("invalid");
    }
    
    // Con: Can't be used as value source
    // [Test]
    // [Description("With invalid skus")]
    // public void Upload_works([ValueSource(typeof(Data), nameof(Data.WithInvalidSkus))]
    //     IReadOnlyList<string> skus)
    // {
    //     // Arrange
    //
    //     // Act
    //
    //     // Assert
    //     // Deliberately fail so we see something in dotnet test output
    //     skus.Should().NotContain("invalid");
    // }
}

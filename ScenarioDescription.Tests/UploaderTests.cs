using FluentAssertions;

namespace ScenarioDescription.Tests;

public class UploaderTests
{
    public static class Data
    {
        public record Scenario(IReadOnlyList<string> Skus, string? Description = null)
        {
            public override string ToString() => Description ?? base.ToString()!;
        }

        public static IEnumerable<Scenario> WithInvalidSkus => new Scenario[]
        {
            new(new List<string> { "invalid" }, "One invalid value"),
            new(new List<string> { "valid", "invalid" }, "One invalid, one valid value")
        };
    }

    [Test]
    [Description("TEST_CASE_DESCRIPTION")]
    public void Upload_works([ValueSource(typeof(Data), nameof(Data.WithInvalidSkus))] Data.Scenario scenario)
    {
        // Arrange
        
        // Act

        // Assert
        true.Should().BeFalse();
    }
}

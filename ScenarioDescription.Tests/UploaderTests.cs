using FluentAssertions;

namespace ScenarioDescription.Tests;

public class UploaderTests
{
    public static class Data
    {
        public record Scenario(IReadOnlyList<string> Skus);
        
        public record ScenarioWithDescription(IReadOnlyList<string> Skus, string? Description = null) : Scenario(Skus)
        {
            // TODO: Don't print empty Description in fallback case
            public override string ToString() => Description ?? base.ToString();
        }

        public static IEnumerable<ScenarioWithDescription> WithInvalidSkus => new ScenarioWithDescription[]
        {
            new(new List<string> { "invalid" }, "One invalid value"),
            new(new List<string> { "valid", "invalid" }, "One invalid, one valid value"),
            new(new List<string> { "invalid", "valid", "invalid" }),
        };
    }

    [Test]
    [Description("TEST_CASE_DESCRIPTION")]
    public void Upload_works([ValueSource(typeof(Data), nameof(Data.WithInvalidSkus))]
        Data.ScenarioWithDescription scenarioWithDescription)
    {
        // Arrange
        
        // Act

        // Assert
        true.Should().BeTrue();
    }
}

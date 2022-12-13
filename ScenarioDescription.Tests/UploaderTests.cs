using FluentAssertions;

namespace ScenarioDescription.Tests;

public record Scenario<TData>(TData Data)
{
    public ScenarioWithDescription<TData> WithDescription(string description) => new(Data, description);
}

public record ScenarioWithDescription<TData>(TData Data, string? Description = null) : Scenario<TData>(Data)
{
    // TODO: Don't print empty Description in fallback case
    public override string ToString() => Description ?? base.ToString();
}

public static class Extensions
{
    public static Scenario<TData> AsScenario<TData>(this TData data) => new(data);
}

public class UploaderTests
{
    public static class Data
    {
        public record ScenarioData(IReadOnlyList<string> Skus);

        public static IEnumerable<Scenario<ScenarioData>> WithInvalidSkus => new[]
        {
            // Bad
            // new Scenario<ScenarioData>(new(new List<string> { "invalid" })).WithDescription("One invalid value"),
            // new Scenario<ScenarioData>(new(new List<string> { "valid", "invalid" })).WithDescription("One invalid, one valid value"),
            // new(new(new List<string> { "invalid", "valid", "invalid" })),
            
            // Better
            new ScenarioData(new List<string> { "invalid" }).AsScenario().WithDescription("One invalid value"),
            new ScenarioData(new List<string> { "valid", "invalid" }).AsScenario().WithDescription("One invalid, one valid value"),
            new ScenarioData(new List<string> { "invalid", "valid", "invalid" }).AsScenario(),
        };
    }

    [Test]
    [Description("With invalid skus")]
    public void Upload_works([ValueSource(typeof(Data), nameof(Data.WithInvalidSkus))]
        Scenario<Data.ScenarioData> scenario)
    {
        // Arrange

        // Act

        // Assert
        scenario.Data.Skus.Should().Contain("invalid");
    }
}

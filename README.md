# ScenarioDescription

## Overview

This is a POC / test project with the goal of making complex test input data more readable in (rider / other ides) unit test explorer and `dotnet test` output.

## Example (Scenario method)

```console
$ dotnet test -c Release --filter "FullyQualifiedName~Scenarios" | grep "Failed "
  Failed Upload_works(One invalid value) [112 ms]
  Failed Upload_works(One invalid, one valid value) [2 ms]
  Failed Upload_works(Scenario { Data = ScenarioData { Skus = System.Collections.Generic.List`1[System.String] } }) [1 ms]
```

Note how the first two tests have a "custom input description" that is readable and how the third test is lacking it (to illustrate the difference).

## Example (TestCaseParameters method)

```console
$ dotnet test -c Release --filter "FullyQualifiedName~TestCaseParameters" | grep "Failed "
  Failed One invalid value [112 ms]
  Failed One valid, one invalid value [1 ms]
  Failed Upload_works(System.Collections.Generic.List`1[System.String]) [< 1 ms]
```

## Comparison

### Scenario Method

#### Pros

* Can be used as `ValueSource` and `TestCaseSource` ➡ Good composability, reusability
* Named parameters in conjunction with `ScenarioData`

#### Cons

* A bit hacky
* `scenario.Data.Prop` is verbose

### TestCaseParameters Method

#### Pros

* Builtin
* Full control over test name
* Data is passed through directly to test method parameters, no `scenario.Data.Prop`

#### Cons

* Can only be used as `TestCaseSource` ➡ Can not be composed easily
* Sets the whole test name and not only part of it, which might be detrimental sometimes
* No type safety at all for what we pass into our different `TestCaseParameters`, since we just pass `object`s ➡ Error prone

# ScenarioDescription

## Overview

This is a POC / test project with the goal of making complex test input data more readable in (rider / other ides) unit test explorer and `dotnet test` output.

## Example

```console
$ dotnet test -c Release | grep "Failed "
  Failed Upload_works(One invalid value) [135 ms]
  Failed Upload_works(One invalid, one valid value) [2 ms]
  Failed Upload_works(Scenario { Data = ScenarioData { Skus = System.Collections.Generic.List`1[System.String] } }) [1 ms]
```

Note how the first two tests have a "custom input description" that is readable and how the third test is lacking it (to illustrate the difference).

Mutable
====

> Everything changes and nothing stands still.
>
> -Heraclitus

Immutability is a fine property of objects, and is very useful when dealing with threading, but there are
times when one is in need of some good old-fashioned change. The `Mutable` library simply interprets text:

```csharp
/* Define some data */
City = "Seattle"; //Fairly recognizable
State = "Washington"; //Note: Not Washington DC!
Country = "USA"; 
IsRaining = true; //Stereotype!
Lat = 47.6097d;
Long = 122.3331f; //Some precision may be lost during shipping
```

...into a series of calls to a delegate you supply: 

```csharp
Mutable.Parse(
  input: text, 
  mutator: (property, value) => city[property] = value);
```

Install via NuGet, and leave any feedback, issues, and pull requests here.

Unit tests are also examples, through the magic of commenting.


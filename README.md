#Mutable

> Everything changes and nothing stands still.
>
> -Heraclitus

The `Mutable` library interprets text-based "traces":

```csharp
/* city.txt */
City = "Seattle"; //Fairly recognizable
State = "Washington"; //Note: Not Washington DC!
Country = "USA"; 
IsRaining = true; //Stereotype!
Lat = 47.6097d;
Long = 122.3331f; //Some precision may be lost during shipping
```

...as arguments for a series of calls to a delegate you supply: 

```csharp
var input = File.ReadAllText("city.txt");
var city = new Dictionary<string, object>();
using (var trace = new Trace(input: input))
{
  trace.Retrace(into: 
    (property, value, comment) => city[property] = value);
}
```

...effectively changing a data structure of your choice based on the sequence of inputs. Mutable is a super-simple API for a tiny markup language based on C#'s literal assignments.

Install via NuGet, and leave any feedback, issues, and pull requests here.

Unit tests are also examples, through the magic of commenting.

##Why another Markup Language?

TL:DR - Mutable is YAML-like but with C# syntactic sugar and DIY semantics.

YAML is pretty succinct, and I like it alright. However, there is a ton of complexity in the parser (once you dig a bit deeper). Most implementors and users skip the "tricky" stuff and stick with nesting property assignments.

Mutable seeks to be a simple, recognizable format for capturing "assignment" data and applying it to a datastructure of your choice. Plus, for the C#/NuGet world, it represents a pretty familiar syntax and "native" feel. 

Through the sneaky trick of monadic parser combinators, Mutable borrows heavily from a well-understood grammar (C#) to get a leg up on representing data. If you have ever used a `const` in a program, then using C# to serialize/deserialize data shouldn't be too unfamiliar.

Sound off in an issue if you have questions/rants/suggestions.

##Creating a Trace

While it is completely acceptable to hand code your traces, you may sometimes want to...er...well...trace them:
using (var trace = new Trace())
{
  trace.DelimitedComment("city.txt");
  trace.Assignment("City", "Seattle", "Fairly recognizable");
  trace.Assignment("State", "Washington", "Note: Not Washington DC");
  trace.Assignment("Country", "USA"); 
  trace.Assignment("IsRaining", "true", "Stereotype!");
  trace.Assignment("Lat", 47.6097d);
  trace.Assignment("Long", 122.3331f, "Some precision may be lost during shipping");
  File.WriteAllText(
    path: "city.txt",
    contents: trace.ToString());
}

##Handling "Duplicates"

So, what if your trace looks like:

```csharp
//Pharrell Williams - Happy
ClapAlong = "If you feel like a room without a roof";
ClapAlong = "If you feel like happiness is the truth";
ClapAlong = "If you know what happiness is to you";
ClapAlong = "If you feel like that's what you wanna do";
```

How you handle your "assignments" is totally up to you. While Mutable borrows from the C# grammar, the semantics are yours to interpret in your delegate. Some approaches are:

 - Take all property assignments, but last one "in" wins
 - Fail if you get the same property twice
 - Partition the assignments using `ILookup<string, object>`
 - Interpret as a collection/array
  
 It is up to you and your delegate. 

##"Nested" Property Assignments

The Mutable grammar is a restriction applied over C# assignments. However, "nested", properties aren't restricted:

```csharp
//Thanks weezer!
In.My.Garage.I.Feel.Safe = true;
```

The property name will be: `"In.My.Garage.I.Feel.Safe"` and you can split and interpret as you will.

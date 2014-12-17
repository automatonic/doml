> Deprecated. I have seen the light, and it has all the features I wanted...plus already coded/supported :}
> https://github.com/toml-lang/toml

#Literal

![Mona](http://www.gravatar.com/avatar/7444a33ea23811592611d964660b7fc6.jpeg?s=128)

> "Hard Code" your data with impunity...just like Charles Dickens

[![Build status](https://ci.appveyor.com/api/projects/status/fh9vtlc97gkh04al/branch/master)](https://ci.appveyor.com/project/automatonic/literal/branch/master)

The `Literal` library stores your data as literal assignments:

```csharp
/* city.txt */
City = "Seattle"; //Fairly recognizable
State = "Washington"; //Note: Not Washington DC!
Country = "USA"; 
IsRaining = true; //Stereotype!
Lat = 47.6097d;
Long = 122.3331f; //Some precision may be lost during shipping
```

...which can be read as a stream of strongly typed tokens (i.e. a `Trace`): 

```csharp
var input = File.ReadAllText("city.txt");
var city = new Dictionary<string, object>(
  Trace
    .Tokenize(input)
    .OfType<LiteralAssignment>() //Ignore delimited comment tokens
    .Select(assigment => 
      new KeyValuePair<string, object>(
        key: assignment.Property, 
        value: assigment.Value))
);

Console.WriteLine(city["Country"]); //outputs "USA"

```
##Features

 - Store data with familiar syntax (C# assignments and literal values)
 - Value types are inferred and automatically parsed into C# primitive types (just as in a C# program)
 - Flexible DIY semantics for properties
    - Support for "dynamic" property assignment (a property is declared/defined simply by assigning a literal to it)
    - Support for "nested" properties ("Parent.Child.Property = true;")
 - Native support for .NET languages
 - Deployed as a NuGet package

##Examples

The unit tests are your best bet for up to date (and working!) examples.

##Motivation

I love the *idea* of YAML, but that is mostly due to the terse nature of its data representation. Why can't a C# developer represent data in a more familiar, and yet flexible way? 

Say we have a program that builds up data using literals and object instantiations:

```csharp
public class Program
{
  public class MyClass
  {
    string Property1 { get; set; }
  }
  static void Main(string[] args)
  {
    int Count = 1; //Disregard the variable casing
    MyClass Instance = new MyClass(); //Disregard the variable casing
    Instance.Property1 = "yes";
  }
}
```

While we can see that data is "marked up" within the text of this program, the representation is unwieldy. We are getting mired in the object accounting that is necessary to make C# strongly typed. What if we ditched everything but the assignment expressions?

```csharp
Count = 1;
Instance.Property1 = "yes";
```

This is much better for terseness, but we are edging into the realm of the "dynamicly typed" languages. The type of `i` is now implicitly coming from the type of the literal value. The assignment of `m` got thrown away entirely. The C# compiler will never go for anything like this without a `dynamic` object preamble, and you would still need a `Main` function and class details to be a valid program, etc.

But what if we disconnected the C# Parser from the C# compiler, and allowed dynamic assignments with minimal boilerplate?

Well, in that case, we would have a `Literal` markup language that feels terse, dynamic, and yet somehow familiar.

##Building a Trace

While it is completely acceptable to hand code your traces (as they are simple strings), the `TraceBuilder` can be used to facilitate this process:

```csharp
var traceBuilder = new TraceBuilder();
traceBuilder.AppendDelimitedComment("city.txt");
traceBuilder.AppendAssignment("City", "Seattle", "Fairly recognizable");
traceBuilder.AppendAssignment("State", "Washington", "Note: Not Washington DC");
traceBuilder.AppendAssignment("Country", "USA"); 
traceBuilder.AppendAssignment("IsRaining", "true", "Stereotype!");
traceBuilder.AppendAssignment("Lat", 47.6097d);
traceBuilder.AppendAssignment("Long", 122.3331f, "Some precision may be lost during shipping");
File.WriteAllText(
  path: "city.txt",
  contents: traceBuilder.ToString());

```

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
  
It is up to you. 

##"Nested" Property Assignments

The Mutable grammar is a restriction applied over C# assignments. However, "nested", properties aren't restricted:

```csharp
//Thanks weezer!
In.My.Garage.I.Feel.Safe = true;
```

The property name will be: `"In.My.Garage.I.Feel.Safe"` and you can split and interpret as you will.

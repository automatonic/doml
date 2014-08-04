DOML (Dynamic Object Markup Language)
====

Given a [dynamic object](http://msdn.microsoft.com/en-us/library/dd537660.aspx) `propertyBag`, and a `text` string that contains:

```csharp
/* Define some data */
City = "Seattle"; //Fairly recognizable
State = "Washington"; //Note: Not Washington DC!
Country = "USA"; 
IsRaining = true; //Stereotype!
Lat = 47.6097d;
Long = 122.3331f; //Some precision may be lost during shipping
```

Apply the `text` assignments to the `propertyBag`:

```csharp
propertyBag.Apply(text);
```



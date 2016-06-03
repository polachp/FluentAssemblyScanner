# FluentAssemblyScanner

### Assembly and type scanner for .NET

### Nuget Packages

```csharp
 // TODO Nuget
 
```

### Examples

```csharp
public static void Program()
{
  // Based on Interface
  IEnumerable<Type> types = AssemblyScanner.FromAssemblyInDirectory(AssemblyFilterFactory.All())
                                           .IncludeNonPublicTypes()
                                           .BasedOn<IAnyInterface>()
                                           .NonStatic()
                                           .Scan();
  // With method name                                         
  IEnumerable<Type> types = AssemblyScanner.FromAssemblyInDirectory(AssemblyFilterFactory.All())
                                           .IncludeNonPublicTypes()
                                           .BasedOn<IDummy>()
                                           .NonStatic()
                                           .UseDefaultfilter()
                                           .WithMethodNamed("DummyMethod")
                                           .Scan();
}
```

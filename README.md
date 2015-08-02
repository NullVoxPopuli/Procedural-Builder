# Procedural Builder Design Pattern
A customized design pattern for use with procedural generation in .NET/C#. The basics of which are grounded in Fluent Builders.

### Terminology
In this, we refer to the current Builder/Model as the "N Link". The first link in generation is known as the "Origin", the predecessor link is known as the "N-1 Link" and the successor is known as the "N+1 link".

## Usage
The usage of ProceduralBuilder is broken down into two steps: a `ProceduralBuilder<T>` and a `GeneratedModel` of type T. The `ProceduralBuilder<T>` abstract class functions identically to a Fluent Builder except it contains three helper methods: `Using()`, `Until()`, and `Flat()`. 
* `Using()` allows an input of a `GeneratedModel` to drive generation of the next link in procedural generation
* `Until()` allows the specification of a specific class, whereby procedural generation will end its linking.
* `Flat()` allows the `ProceduralBuilder<T>` to build a `GeneratedModel` without any procedural generation linking
The `GeneratedModel` abstract class contains the virtual `ProceduralBuild()` method, which is where the N-1 link is used to drive all procedurally-generated fields. Any subclasses of `GeneratedModel` should be created here through the use of their respective `ProceduralBuilder<T>` implementations.

###Example Implementation: `ProceduralBuilder<T>`
```C#
public class ExampleParentBuilder : ProceduralBuilder<ExampleParent>
{
  private double _someValue = Constants.DefaultDouble;
  private List<ExampleChild> _exampleChildren;

  // Master Procedural-Build. Starts the chain of generation here
  public override ExampleParent BuildInitialModel()
  {
    return new ExampleParent()
    {
      SomeValue = _someValue,
      Children = _exampleChildren,
    };
  }

  // Used for creating default object Relationships to prevent nulls
  public override void SetRelationshipDefaults()
  {
    if (_exampleChildren == null)
    {
      _exampleChildren = new List<ExampleChild>();
    }
  }

  // FLUENT BUILDER HELPERS
  public ExampleParentBuilder WithSomeValue(double value)
  {
    _someValue = value;
    return this;
  }
  
  public ExampleParentBuilder WithExampleChildren(List<ExampleChild> children)
  {
    _exampleChildren = children;
    return this;
  }
}
```

###Example Implementation: `GeneratedModel`
```C#
public class ExampleParent : GeneratedModel
{
  public double SomeValue;
  public List<ExampleChild> Children;
  
  public override void ProceduralBuild(GeneratedModel from, Type until = null)
  {
    if(from != null)
    {
      // Do mathematics on our fields (specifically SomeValue) using values in 'from'
    }
    
    if(Children.Count == 0)
    {
      // Continue the chain
      Children.Add(new ExampleChildBuilder()
        .Using(this)
        .Until(until)
        .Build();
    }
  }
}
```

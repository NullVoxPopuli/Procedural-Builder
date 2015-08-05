# Procedural Builder Design Pattern
A customized design pattern for use with procedural generation in .NET/C#. The basics of which are grounded in Fluent Builders.

### Terminology
In this, we refer to the current Builder/Model as the "N Link". The first link in generation is known as the "Origin", the predecessor link is known as the "N-1 Link" and the successor is known as the "N+1 link".

## Usage
The usage of ProceduralBuilder is broken down into two steps: a `ProceduralBuilder<T>` and a `GeneratedModel` of type T. The `ProceduralBuilder<T>` abstract class functions identically to a Fluent Builder except it contains three helper methods: `Using()`, `Until()`, and `Flat()`. 
* `Using()` allows an input of a `GeneratedModel` to drive generation of the next link in procedural generation
* `Until()` allows the specification of a specific class, whereby procedural generation will end its linking.
* `Flat()` allows the `ProceduralBuilder<T>` to build a `GeneratedModel` without any procedural generation linking

The `GeneratedModel` abstract class is simply a basis for driving `ProceduralBuilder<T>`. It does not contain any methods or parameters.

###Example Origin Implementation: `ParentBuilder`
```C#
public class ParentBuilder : ProceduralBuilder<ParentModel>
{
    private int _rangeMultiplier = 0;
    private List<ChildModel> _children; 

    protected override ParentModel BuildInitialModel()
    {
        return new ParentModel()
        {
            Children = _children,
            RangeMultiplier = _rangeMultiplier
        };
    }

    protected override void SetRelationshipDefaults()
    {
        if (_children == null)
        {
            _children = new List<ChildModel>();
        }
    }

    // Actual Procedural Generation
    protected override void ProcedurallyGenerate(ParentModel output)
    {
        if (_until != typeof(ChildModel))
        {
            GenerateChildren(output);
        }
    }

    private void GenerateChildren(ParentModel output)
    {
        if (output.Children.Count != 0) return;

        // Randomly generate 1-4 children
        var numChildren = Dice.Roll(numberOfSides: 4, numberOfTimes: 1) + 1;
        for (var cont = 0; cont < numChildren; ++cont)
        {
            output.Children.Add(new ChildBuilder()
                .Using(output)
                .Build());
        }
    }

    // Fluent Builders
    public ParentBuilder WithRangeMultiplier(int rangeMultiplier)
    {
        _rangeMultiplier = rangeMultiplier;
        return this;
    }

    public ParentBuilder WithChildren(List<ChildModel> children)
    {
        _children = children;
        return this;
    }
}
```

###Example N+1 Implementation: `ChildBuilder`
```C#
public class ChildBuilder : ProceduralBuilder<ChildModel>
{
    private int _minimum = 0;
    private int _maximum = 0;

    protected override void SetRelationshipDefaults() { }
    protected override ChildModel BuildInitialModel()
    {
        return new ChildModel()
        {
            Maximum = _maximum,
            Minimum = _minimum
        };
    }

    // Actual Procedural Generation
    protected override void ProcedurallyGenerate(ChildModel output)
    {
        if (_from is ParentModel)
        {
            GenerateFromParent(output);
        }
    }

    private void GenerateFromParent(ChildModel output)
    {
        output.Minimum = ((ParentModel)_from).RangeMultiplier * 4;
        output.Maximum = output.Minimum + 1 + Dice.Roll(4);
    }

    // Fluent Builders
    public ChildBuilder WithMinimum(int min)
    {
        _minimum = min;
        return this;
    }

    public ChildBuilder WithMaximum(int max)
    {
        _maximum = max;
        return this;
    }
}
```

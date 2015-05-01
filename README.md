# Procedural Generation Engine (PGE)
A procedural generation engine (Core) with an optional extension (Fantasy World). The goal of this project was to examine different uses of Factories and Gang of Four design patterns.

## Usage
PGE is extremely easy to use in your code at the moment. It is essentially a Builder with very little additional features. Please be patient, this system is still very new and many features need to be implemented.

```C#
var generationParameters = new GenericObjectGenerationParameters();

var generator = new Generator<GenericObject>();
generator.Add(generationParameters);

GenericObject generatedObject = generator.Build();

```

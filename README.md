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

## Fantasy World
"Fantasy World" is an extension provided as an example for PGE's capabilities. It is my attempt to procedurally generate fantasy worlds complete with vibrant histories. Characters in this world will be capable of adapting to their environments, civilizations will fall into ruins from diseases and war, and so on and so forth. This is fairly ambitious but I think it will be a lot of fun.

# Auxo.Net

A StrongLoop for Asp.Net Core


[![Travis build status](https://travis-ci.org/allangomessl/Auxo.Net.svg?branch=master)](https://travis-ci.org/allangomessl/Auxo.Net/builds)

### Depencies
- [FluentValidation](https://github.com/JeremySkinner/FluentValidation)


### Features

##### Localization with JSON
```json
pt-bt.json
{
  "hello_world": "Olá Mundo"
}
```

##### Validation Integrated
```C#
RuleFor(c => c.Name).NotEmpty().Length(5, 40);
```

##### Messages
```C#
Message.Raise(new Message("Validation", "Error ao validar Nome"));
```

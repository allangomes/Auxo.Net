# Auxo.Net 1.0.0  [![Travis build status](https://travis-ci.org/allangomessl/Auxo.Net.svg?branch=master)](https://travis-ci.org/allangomessl/Auxo.Net/builds)

A StrongLoop for Asp.Net Core

### Depencies
- [FluentValidation](https://github.com/JeremySkinner/FluentValidation)


---
### Localization with JSON
```C#
pt-bt.json
{
  "hello_world": "Olá Mundo"
}
L.T("hello_world"); //Olá Mundo
```
---
### Security
```C#
public class User
{
     string Login { get; set; }
     Secure Password { get; set; }
}

$ user.Login = "allan";
$ user.Password = PBKDF2.Encrypt("allan");

$ user.Password == "allan"; // true
$ user.Password == "bllan"; // false

$ user.Password.Hash = "dsadasdas" //ERROR: Private Set Only (Imutable)
```
##### Dababase Secure Table
| Algorithm | Hash                 | Salt           | Parameters |
|-----------|----------------------|----------------|------------|
| PBKDF2    | +WqsZSS2m8iId8QQ.... | fcOMenFOG3y... | 64000      |
---
### Validation Integrated
```C#
RuleFor(c => c.Name).NotEmpty().Length(5, 40);
```
---
### Messages
```C#
Message.Raise(new Message("Validation", "Error ao validar Nome"));
```

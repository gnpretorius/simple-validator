# SimpleValidator
A simple .Net validation library written in C#

It's based largely on the [FluentValidation](https://github.com/JeremySkinner/FluentValidation) libary with some changes in it's usage. 

## Extension methods
As a start, there are some simple extension method you can use. 

Include the following using statement:

```using SimpleValidator.Extensions;```

Then you should have some usefull helper methods as shown below:

```
string email = "test@email.com";

email.IsLength(5)
email.IsEmail()
email.IsMatch("test2@email.com")
```

Taking it a bit further, let's create a validator object. From there you can use it to validate several properties of an object with a few overrides as shown below

```
SimpleValidator.Validator validator = new SimpleValidator.Validator();

validator.IsEmail("test@email.com"); // value
validator.IsEmail("Email", "test@email.com"); // name, value
validator.IsEmail("Email", "test@email.com", "Please enter a valid email address"); // name, value, message
```

It supports chaining so you could write it as follows

```
validator
  .IsEmail("test@email.com")
  .IsEmail("Email", "test@email.com")
  .IsEmail("Email", "test@email.com", "Please enter a valid email address");
```

This is quite usefull for more complex object validation e.g.


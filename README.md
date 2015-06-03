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
```
// validate the name
validator
    .NotNull(name)
        .WithMessage("Name cannot be an empty string")
    .IsLength(name, 5)
        .WithMessage("Name must be at least 5 characters long")
    .IsLength(name, 5, 20)
        .WithMessage("Name must between 5 and 20 characters")
    .Must(() =>
        {
            return name.Contains("abc");
        }).WithMessage("Name cannot contain abc")
    .MustNot(() =>
        {
            return name.Contains("bob");
        }).WithMessage("Name cannot contain bob");
```

Each of the messages are added to an Error collection within the validator object. It also has a ```IsValid``` property. The validation is done as the method is called, which means you can stagger the validation is needed e.g. 

```
string name = "Gordon";

// validate the name
validator
    .NotNull(name).WithMessage("Name cannot be an empty string");

if (validator.IsValid)
{
    // do something here that is dependant on name not being null

    validator.Must(() =>
    {
        // some other condition
        return true;
    });

    if (validator.IsValid)
    {
        // and down the rabit hole we go...
    }
}
```

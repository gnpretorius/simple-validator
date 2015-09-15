# SimpleValidator

A simple .Net validation library written in C#

It's based largely on the [FluentValidation](https://github.com/JeremySkinner/FluentValidation) libary with some changes in it's usage. 

##Why SimpleValidator?

I needed a validation library that satisfied the following criteria:

- Quick simple validation checks
- Complex business rule validation
- Multiple stages of validation (i.e. do the simple stuff first, then more complex validation, but don't bother with the complex stuff if the simple stuff fails)
- Avoid attribute based validation (I try to avoid using attributes. People think, I've validated my MVC model so my service method should be good to good. Not the case. Service methods should always validate everything as you cannot guarantee validation has been performed)
- Readable
- Central

What I came up with was the following...

As there is quite a bit to cover I'm going to start simply, and add complexity. 

## Validator

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
    .NotNull(name).WithMessage("Name cannot be an empty string")
    .IsLength(name, 5).WithMessage("Name must be at least 5 characters long")
    .IsLength(name, 5, 20).WithMessage("Name must between 5 and 20 characters")
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

## Extension methods
As a start, there are some simple extension method you can use. 

Include the following using statement:

```using SimpleValidator.Extensions;```

Then you should have some useful helper methods as shown below:

```
string email = "test@email.com";

email.IsLength(5)
email.IsEmail()
email.IsMatch("test2@email.com")
```

The full list of extension methods is as follows:

```
// string based extension methods (IsNotNullOrEmpty and IsNotNullOrWhiteSpace are the only methods that have inverse tests. The assumption is to always assume the positive.
[string].IsNotNullOrEmpty();
[string].IsNullOrEmpty();
[string].IsNotNullOrWhiteSpace();
[string].IsNullOrWhiteSpace();
[string].IsBetweenLength(int min, int max);
[string].IsMaxLength(int max);
[string].IsMinLength(int min);
[string].IsExactLength(int length);
[string].IsEmail()
[string].IsPassword()
[string].IsCreditCard()
[string].IsMatch()

// object based extension methods
[object].IsNotNull()
[object].IsNull()
[object].IsNot()


```

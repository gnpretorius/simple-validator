# SimpleValidator

A simple .Net validation library written in C#

It's based largely on the [FluentValidation](https://github.com/JeremySkinner/FluentValidation) libary with some changes in it's usage. 

## Why SimpleValidator?

I needed a validation library that satisfied the following criteria:

- Quick and simple validation checks
- Complex business rule validation
- Multiple stages of validation (i.e. do the simple stuff first, then more complex validation, but don't bother with the complex stuff if the simple stuff fails)
- Avoid attribute based validation (I try to avoid using attributes. People think, I've validated my MVC model so my service method should be good to go. Not the case. Service methods should always validate everything as you cannot guarantee validation has been performed)
- Readable
- Central

What I came up with was the following...

As there is quite a bit to cover I'm going to start simply, and add complexity. 

## Structure

There is 2 types of validation you can perform using SimpleValidator. **Extension methods** and **Validator**. The validator 
essentially uses the extension methods behind the scenes but provides a useful wrapper for doing your validations. 

## Extension methods

As a start, there are some simple extension method you can use. 

Include the following using statement:

```using SimpleValidator.Extensions;```

Then you should have some useful helper methods as shown below:

```
string email = "test@email.com";

if (email.IsLength(5)) ...
if (email.IsEmail()) ...
if (email.IsMatch("test2@email.com")) ...
if (email.IsInt()) ...
if (email.IsNumber()) ...
```

The full list of extension methods is as follows:

```
// string based extension methods (IsNotNullOrEmpty and IsNotNullOrWhiteSpace are the only methods that have inverse tests. The assumption is to always assume the positive.
[string].IsNotNullOrEmpty
[string].IsNullOrEmpty
[string].IsNotNullOrWhiteSpace
[string].IsNullOrWhiteSpace();
[string].IsBetweenLength
[string].IsMaxLength
[string].IsMinLength
[string].IsExactLength
[string].IsEmail
[string].IsPassword
[string].IsCreditCard
[string].IsEqualTo

// object based extension methods
[object].IsNotNull
[object].IsNull
[object].Is
[object].IsNot
[object].IsRule // validating against an interface for more complex business rules
[object].IsInt
[object].IsShort
[object].IsLong
[object].IsDouble
[object].IsBool
[object].IsNumber

// integer (same dor double, decimal, short and long)
[integer].IsNotZero
[integer].IsEqualTo
[integer].IsGreaterThan
[integer].IsLessThan
[integer].IsBetween

// datetime
[datetime].IsDate
[datetime].IsGreaterThan
[datetime].IsGreaterThanOrEqualTo
[datetime].IsLessThan
[datetime].IsLessThanOrEqualTo
[datetime].IsEqualTo
[datetime].IsBetween
[datetime].IsGreaterThanDateOnly
[datetime].IsGreaterThanOrEqualToDateOnly
[datetime].IsLessThanDateOnly
[datetime].IsLessThanOrEqualToDateOnly
[datetime].IsEqualToDateOnly
[datetime].IsBetweenDateOnly
```

## Validator

Extension methods work great for quick simple checks, but you probably want to do more complex validation. 

For this, lets create a Validator object. From there you can use it to validate several properties of an object with a few overrides as shown below

Remember to include ```using SimpleValidator;```

For each text method you have the following overrides:

```
SimpleValidator.Validator validator = new Validator();

// value
validator.IsEmail("test@email.com");

// name, value
validator.IsEmail("Email", "test@email.com");

// name, value, message
validator.IsEmail("Email", "test@email.com", "Please enter a valid email address");

if (validator.IsValid())
{
    // everything is good
}
else
{
    // validator.Errors contains a name / message dictionary of your errors 
}

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



using SimpleValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleValidator.Extensions
{
    /// <summary>
    /// Always use the positive route i.e. a true result should indicate validity therefore generally prefix with "Is"
    /// e.g. This field is not zero
    /// </summary>
    public static class ExtensionMethods
    {
        #region " String "

        #region " Nullable, Empty & Whitespace "

        /// <summary>
        /// This is simply a shorthand method "!string.IsNullOrEmpty(value)"
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>true is the value is not null or it's length != 0</returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Inverse of <see cref="IsNotNullOrEmpty"/> method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return !value.IsNotNullOrEmpty();
        }

        /// <summary>
        /// This is simply a shorthand method "!string.IsNullOrEmpty(value)"
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>true is the value is not null or it's length != 0</returns>
        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Inverse of <see cref="IsNotNullOrWhiteSpace"/> method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return !value.IsNotNullOrWhiteSpace();
        }

        #endregion

        #region " Lengths "

        /// <summary>
        /// Checks if this string is between the min and max values (inclusive)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min">Inclusive min length</param>
        /// <param name="max">Inclusive max length</param>
        /// <returns></returns>
        public static bool IsBetweenLength(this string value, int min, int max)
        {
            if (value.IsNull() && min == 0)
            {
                return true; // if it's null it has length 0
            }
            else if (value.IsNull())
            {
                return false;
            }
            else
            {
                return value.Length >= min && value.Length <= max;
            }
        }

        /// <summary>
        /// Checks if the string is at least max characters
        /// </summary>
        /// <param name="value"></param>
        /// <param name="max">Inclusive max length</param>
        /// <returns></returns>
        public static bool IsMaxLength(this string value, int max)
        {
            if (value.IsNull())
            {
                return true; // if it's null it has length 0 and that has to be less than max
            }
            else
            {
                return value.Length <= max;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static bool IsMinLength(this string value, int min)
        {
            if (value.IsNull() && min == 0)
            {
                return true; // if it's null it has length 0
            }
            else if (value.IsNull())
            {
                return false;
            }
            else
            {
                return value.Length >= min;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool IsExactLength(this string value, int length)
        {
            return value.IsBetweenLength(length, length);
        }

        #endregion

        #region " Misc "

        /// <summary>
        /// Check if the current value is a valid email address. It uses the following regular expression
        /// ^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$
        /// null values will fail.
        /// Empty strings will fail.
        /// It performs the check from method <see cref="IsNotNullOrEmpty"/>
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns>True if the value is a valid email address</returns>
        public static bool IsEmail(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false; // if it's null it cannot possibly be an email
            }
            else
            {
                string exp = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";

                return new Regex(exp, RegexOptions.IgnoreCase).IsMatch(value);
            }
        }

        /// <summary>
        /// Checks if the current value is a password. The password must be at least 8 characters, at least 1 uppercase character, at least 1 lowercase character, at least one number and a maximum of 30 characters.
        /// It uses the following regular expression
        /// ^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPassword(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false; // if it's null it cannot possibly be a password
            }
            else
            {
                string exp = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,30}$";

                return new Regex(exp, RegexOptions.IgnoreCase).IsMatch(value);
            }
        }

        /// <summary>
        /// Validates if the specified object passes the regular expression provided. If the object is null, it will fail. The method calls ToString on the object to get the string value.
        /// </summary>
        /// <param name="value">The value to be evaluated</param>
        /// <param name="exp">The regular expression</param>
        /// <returns></returns>
        public static bool IsRegex(this string value, string exp)
        {
            if (value.IsNotNullOrEmpty())
            {
                return false;
            }

            string check = value.ToString();

            return new Regex(exp, RegexOptions.IgnoreCase).IsMatch(check);
        }

        /// <summary>
        /// Determines if a string is a valid credit card number
        /// Taken from https://github.com/JeremySkinner/FluentValidation/blob/master/src/FluentValidation/Validators/CreditCardValidator.cs
        /// Uses code from: http://www.beachnet.com/~hstiles/cardtype.html
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsCreditCard(this string value)
        {
            if (value.IsNotNullOrEmpty())
            {
                value = value.Replace("-", "").Replace(" ", "");

                int checksum = 0;
                bool evenDigit = false;

                foreach (char digit in value.ToCharArray().Reverse())
                {
                    if (!char.IsDigit(digit))
                    {
                        return false;
                    }

                    int digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                    evenDigit = !evenDigit;

                    while (digitValue > 0)
                    {
                        checksum += digitValue % 10;
                        digitValue /= 10;
                    }
                }

                return (checksum % 10) == 0;
            }
            else
            {
                return false; // a null or empty string cannot be a valid credit card
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this string value, string compare)
        {
            if (value.IsNull() && compare.IsNull())
            {
                return true;
            }
            if (value.IsNull() || compare.IsNull())
            {
                return false;
            }
            return String.Equals(value, compare, StringComparison.Ordinal);
        }

        #endregion

        #endregion

        #region " Object "

        /// <summary>
        /// Check if the current object is not equal to null
        /// </summary>
        /// <param name="value">The object to check</param>
        /// <returns>true is the value is not null</returns>
        public static bool IsNotNull(this object value)
        {
            return (value != null);
        }

        /// <summary>
        /// Inverse of <see cref="IsNotNull"/> method
        /// </summary>
        /// <param name="value">The object to check</param>
        /// <returns>true is the value is null</returns>
        public static bool IsNull(this object value)
        {
            return !value.IsNotNull();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool Is(this object value, Func<bool> func)
        {
            return func();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool IsNot(this object value, Func<bool> func)
        {
            return !func();
        }

        #region " IsRule "

        /// <summary>
        /// Pass in an instance of an object that implements IRule
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool IsRule(this object value, IRule rule)
        {
            return rule.IsValid();
        }

        #endregion

        #endregion

        #region " Integer "

        public static bool IsNotZero(this int value)
        {
            return (value != 0);
        }

        public static bool Is(this int value, int compare)
        {
            return (value == compare);
        }

        public static bool IsGreaterThan(this int value, int min)
        {
            return (value >= min);
        }

        public static bool IsLessThan(this int value, int max)
        {
            return (value <= max);
        }

        public static bool IsBetween(this int value, int min, int max)
        {
            return (value <= max && value >= min);
        }

        #endregion

        #region " DateTime "

        #region " IsDate "

        public static bool IsDate(this object value)
        {
            return value.IsDate(CultureInfo.InvariantCulture);
        }

        public static bool IsDate(this object value, CultureInfo info)
        {
            return value.IsDate(CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        public static bool IsDate(this object value, CultureInfo info, DateTimeStyles styles)
        {
            if (value.IsNotNull())
            {
                DateTime result;

                if (DateTime.TryParse(value.ToString(), info, styles, out result))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false; // if it's null it cannot be a date
            }
        }

        #endregion

        #region " Date Comparisons "

        public static bool IsGreaterThan(this DateTime value, DateTime compare)
        {
            return value > compare;
        }

        public static bool IsGreaterThanOrEqualTo(this DateTime value, DateTime compare)
        {
            return value >= compare;
        }

        public static bool IsLessThan(this DateTime value, DateTime compare)
        {
            return value < compare;
        }

        public static bool IsLessThanOrEqualTo(this DateTime value, DateTime compare)
        {
            return value <= compare;
        }

        public static bool IsEqualTo(this DateTime value, DateTime compare)
        {
            return value == compare;
        }

        public static bool IsBetweenInclusive(this DateTime value, DateTime from, DateTime to)
        {
            return value >= from && value <= to;
        }

        public static bool IsBetweenExclusive(this DateTime value, DateTime from, DateTime to)
        {
            return value > from && value < to;
        }
        
        #endregion

        #endregion

        #region " Helpers "

        public static string EmptyStringIfNull(this string value)
        {
            if (value.IsNull())
            {
                return string.Empty;
            }
            else
            {
                return value;
            }
        }

        #endregion

        #region " GetName "

        // Code taken from http://joelabrahamsson.com/getting-property-and-method-names-using-static-reflection-in-c/

        public static string GetName<T>(this T instance, Expression<Func<T, object>> expression)
        {
            return GetName(expression);
        }

        public static string GetName<T>(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(
                    "The expression cannot be null.");
            }

            return GetName(expression.Body);
        }

        public static string GetName<T>(this T instance, Expression<Action<T>> expression)
        {
            return GetName(expression);
        }

        public static string GetName<T>(Expression<Action<T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(
                    "The expression cannot be null.");
            }

            return GetName(expression.Body);
        }

        private static string GetName(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(
                    "The expression cannot be null.");
            }

            if (expression is MemberExpression)
            {
                // Reference type property or field
                var memberExpression =
                    (MemberExpression)expression;
                return memberExpression.Member.Name;
            }

            if (expression is MethodCallExpression)
            {
                // Reference type method
                var methodCallExpression =
                    (MethodCallExpression)expression;
                return methodCallExpression.Method.Name;
            }

            if (expression is UnaryExpression)
            {
                // Property, field of method returning value type
                var unaryExpression = (UnaryExpression)expression;
                return GetName(unaryExpression);
            }

            throw new ArgumentException("Invalid expression");
        }

        private static string GetName(UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MethodCallExpression)
            {
                var methodExpression =
                    (MethodCallExpression)unaryExpression.Operand;
                return methodExpression.Method.Name;
            }

            return ((MemberExpression)unaryExpression.Operand)
                .Member.Name;
        }

        #endregion

        #region " Type Test "

        public static bool Is<T>(this object value)
        {
            if (value == null)
            {
                return false;
            }

            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));

            try
            {
                T result = (T)converter.ConvertFromString(value.ToString());
                return result != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsInt(this object value)
        {
            return value.Is<int>();
        }

        public static bool IsShort(this object value)
        {
            return value.Is<short>();
        }

        public static bool IsLong(this object value)
        {
            return value.Is<long>();
        }

        public static bool IsDouble(this object value)
        {
            return value.Is<Double>();
        }

        public static bool IsDecimal(this object value)
        {
            return value.Is<Decimal>();
        }

        public static bool IsBool(this object value)
        {
            return value.Is<bool>();
        }

        public static bool IsNumber(this object value)
        {
            return
                value.IsLong() ||
                value.IsDouble() ||
                value.IsDecimal() ||
                value.IsDouble();
        }

        #endregion

        #region " To "

        public static T To<T>(this object value)
        {
            return value.To<T>(default(T));
        }

        public static T To<T>(this object value, T fallback)
        {
            if (value == null)
            {
                return fallback;
            }

            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                try
                {
                    return (T)converter.ConvertFromString(value.ToString());
                }
                catch (Exception)
                {
                    return fallback;
                }

            }
            return fallback;
        }

        public static int ToInt(this object value, int fallback = default(int))
        {
            return value.To<int>(fallback);
        }

        public static short ToShort(this object value, short fallback = default(short))
        {
            return value.To<short>(fallback);
        }

        public static long ToLong(this object value, long fallback = default(long))
        {
            return value.To<long>(fallback);
        }

        public static double ToDouble(this object value, double fallback = default(double))
        {
            return value.To<double>(fallback);
        }

        public static decimal ToDecimal(this object value, decimal fallback = default(decimal))
        {
            return value.To<decimal>(fallback);
        }

        public static bool ToBool(this object value, bool fallback = default(bool))
        {
            return value.To<bool>(fallback);
        }

        #endregion
    }
}
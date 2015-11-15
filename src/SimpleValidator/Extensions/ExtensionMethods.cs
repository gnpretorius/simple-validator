using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleValidator.Extensions
{
    public static class ExtensionMethods
    {
        #region " Validation Methods "

        /// <summary>
        /// Check if the value is equal to null
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns>True if the value is null</returns>
        public static bool IsNull(this object value)
        {
            return (value == null);
        }

        /// <summary>
        /// Check if the integer is equal to zero
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool NotZero(this int value)
        {
            return (value != 0);
        }

        /// <summary>
        /// Check if the value is an empty string i.e. length == 0 (Also returns true if the value is null)
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns>True if the value is null or it's length == 0</returns>
        public static bool IsEmpty(this string value)
        {
            if (value.IsNull())
            {
                return true; // if an item is null, it must be empty
            }
            else
            {
                return (value.Length == 0);
            }

        }

        /// <summary>
        /// Check if the current value is null or empty
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns>True if the value is null or empty</returns>
        public static bool IsNullOrEmpty(this string value) // this is a shortcut method to the above
        {
            return value.IsEmpty();
        }

        /// <summary>
        /// Checks to see if the current object is null, or if it's a string, if it's empty
        /// </summary>
        /// <param name="value">The object to check</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object value) // this is a shortcut method to the above
        {
            if (value == null)
                return true;

            if (value is string)
                return ((string)value).IsEmpty();

            return false;
        }

        /// <summary>
        /// Check if the current value is a valid email address. It uses the following regular expression
        /// ^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$
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
        /// Checks if the current value is a password. The password must be at least 8 characters, at least 1 uppercase character, at least 1 lowercase character, at least one number and a maximum of 15 characters.
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
                string exp = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";

                return new Regex(exp, RegexOptions.IgnoreCase).IsMatch(value);
            }
        }

        public static bool IsMatch(this string value, string compare)
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

        public static bool IsLength(this string value, int min)
        {
            if (value.IsNullOrEmpty())
            {
                return false; // if it's null it has length 0
            }
            else
            {
                return value.Length >= min;
            }
        }

        public static bool IsLength(this string value, int min, int max)
        {
            if (value.IsNullOrEmpty())
            {
                return false; // if it's null it has length 0
            }
            else
            {
                return value.Length >= min && value.Length <= max;
            }
        }

        public static bool IsExactLength(this string value, int length)
        {
            if (value.IsNullOrEmpty())
            {
                return false; // if it's null it has length 0
            }
            else
            {
                return value.Length == length;
            }
        }

        #endregion

        #region " Helpers "

        public static string EmptyStringIfNull(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return "";
            }
            else
            {
                return value;
            }
        }

        #endregion
    }
}

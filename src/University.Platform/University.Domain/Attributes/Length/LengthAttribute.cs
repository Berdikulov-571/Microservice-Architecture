using System.ComponentModel.DataAnnotations;

namespace University.Domain.Attributes.Length
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class LengthAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string email = value.ToString();

            if (System.Text.RegularExpressions.Regex.IsMatch(email, @"^.{5,}$"))
            {
                return true;
            }

            return false;
        }
    }
}

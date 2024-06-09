using System.ComponentModel.DataAnnotations;

namespace WinFormsApp2
{
    public class IDAttribute : ValidationAttribute
    {
        public IDAttribute()
        {
            ErrorMessage = "ID должен содержать только цифры.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            string input = value.ToString();

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class DurationValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string duration = value as string;
            if (TimeSpan.TryParseExact(duration, "hh\\:mm\\:ss", CultureInfo.CurrentCulture, out TimeSpan interval))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Invalid duration. Format: hh:mm:ss");
            }
        }
    }
}
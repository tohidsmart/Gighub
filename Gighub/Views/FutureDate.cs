using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Gighub.Views
{
	public class FutureDate : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			DateTime dateTime;
			bool isValid = DateTime.TryParseExact(Convert.ToString(value), "dd MMM yyyy",
				CultureInfo.CurrentCulture,
				DateTimeStyles.None,
				out dateTime);
			return (isValid && dateTime > DateTime.Now);
		}
	}
}
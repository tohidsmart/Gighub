﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Gighub.Views
{
	public class FutureTime : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			DateTime dateTime;
			bool isValid = DateTime.TryParseExact(Convert.ToString(value), "HH:mm",
				CultureInfo.CurrentCulture,
				DateTimeStyles.None,
				out dateTime);
			return (isValid && dateTime > DateTime.Now);
		}
	}
}
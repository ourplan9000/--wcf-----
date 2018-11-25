/*
 * RePaver
 * 
 * Copyright (c)2009, Daniel McGaughran
 * 
 * Licence:	CodeProject Open Licence (CPOL) 1.2
 *			Please refer to 'Licence.txt' for further details of this licence.
 *			Alternatively, the licence may be viewed at:
 *			http://www.codeproject.com/info/cpol10.aspx
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Globalization;
 

namespace RePaver.Converters
{
	[ValueConversion(typeof(int), typeof(bool))]
	public class FlipSettingConverter : IValueConverter
	{
		private const int _bitMask = 0x7;


		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int flipSetting = (int)value;
			int desiredFlipSetting = 0;
			Int32.TryParse(parameter.ToString(), out desiredFlipSetting);

			bool isMatch = (flipSetting == (desiredFlipSetting & _bitMask));

			return isMatch;
		}



		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}


	}
}

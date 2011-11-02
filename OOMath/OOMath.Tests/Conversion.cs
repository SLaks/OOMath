using System;
namespace OOMath.Tests {
	static class Conversion {
		public static Natural ToNatural(this long num) {
			if (num < 0) throw new ArgumentOutOfRangeException("num");

			var retVal = Natural.Zero;
			for (long i = 0; i < num; i++)
				retVal = new Natural(retVal);
			return retVal;
		}

		public static Integer ToInteger(this long num) {
			if (num == 0)
				return Integer.Zero;
			else if (num < 0)
				return Integer.Negative(ToNatural(-num));
			else
				return Integer.Positive(ToNatural(num));
		}

		public static int ToInt32(this Natural num) {
			int retVal = 0;
			for (var i = num; i != Natural.Zero; i = i.Previous)
				retVal++;
			return retVal;
		}

		public static int ToInt32(this Integer num) {
			return num.IsPositive ? num.Magnitude.ToInt32() : -num.Magnitude.ToInt32();
		}
	}
}
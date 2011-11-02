using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OOMath {
	public class NumberFormatter {
		public ReadOnlyCollection<char> Digits { get; private set; }
		public int Base { get { return Digits.Count; } }

		public NumberFormatter(params char[] digits) {
			if (digits == null) throw new System.ArgumentNullException("digits");
			Digits = new ReadOnlyCollection<char>(digits);
		}
		public NumberFormatter(IEnumerable<char> digits) : this(digits.ToArray()) { }

		public static readonly NumberFormatter Base10 = new NumberFormatter('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
		public static NumberFormatter ForBase(int toBase) {
			if (toBase < 2 || toBase > 36) throw new System.ArgumentOutOfRangeException("toBase");
			if (toBase <= 10)
				return new NumberFormatter(Base10.Digits.Take(toBase));
			else
				return new NumberFormatter(Base10.Digits
						  .Concat(Enumerable.Range(0, toBase - 10).Select(i => (char)(i + 'A')))
				);
		}

		public string ToString(Natural number) {
			IList<int> resultDigits = new List<int> { 0 };
			for (var i = number; i != Natural.Zero; i = i.Previous) {
				Increment(resultDigits, 0);
			}
			return string.Concat(resultDigits.Reverse().Select(i => Digits[i]));
		}
		private void Increment(IList<int> list, int position) {
			list[position]++;
			if (list[position] == Base) {
				list[position] = 0;
				if (position == list.Count - 1)
					list.Add(1);
				else
					Increment(list, position + 1);
			}
		}
	}

	partial class Natural {
		public override string ToString() { return NumberFormatter.Base10.ToString(this); }
	}
}
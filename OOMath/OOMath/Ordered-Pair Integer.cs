namespace OOMath {
	//http://en.wikipedia.org/wiki/Integer#Construction

	public partial class Integer : System.IEquatable<Integer>, System.IComparable<Integer> {
		public static readonly Integer MinusOne = new Integer(Natural.Zero, Natural.One);
		public static readonly Integer Zero = new Integer(Natural.Zero, Natural.Zero);
		public static readonly Integer One = new Integer(Natural.One, Natural.Zero);

		private Natural A { get; set; }
		private Natural B { get; set; }

		private Integer(Natural a, Natural b) { A = a; B = b; }

		#region Conversion
		public static Integer Positive(Natural magnitude) {
			if (magnitude == null) throw new System.ArgumentNullException("magnitude");

			return new Integer(magnitude, Natural.Zero);
		}
		public static Integer Negative(Natural magnitude) {
			if (magnitude == null) throw new System.ArgumentNullException("magnitude");
			return new Integer(Natural.Zero, magnitude);
		}
		public static implicit operator Integer(Natural value) {
			return Positive(value);
		}
		#endregion

		#region Equality
		public override bool Equals(object obj) { return Equals(obj as Integer); }
		public bool Equals(Integer other) {
			if (ReferenceEquals(other, null)) return false;

			return this.A + other.B == other.A + this.B;
		}

		public static bool operator !=(Integer a, Integer b) { return !(a == b); }
		public static bool operator ==(Integer a, Integer b) { return object.Equals(a, b); }

		public override int GetHashCode() {
			return Magnitude.GetHashCode() + (IsPositive ? 23 : 31);
		}
		#endregion

		#region Comparisons
		public int CompareTo(Integer other) {
			if (other == null) return 1;

			return (this.A + other.B).CompareTo(other.A + this.B);
		}
		public static bool operator <(Integer x, Integer y) {
			if (ReferenceEquals(x, y)) return false;
			if (ReferenceEquals(x, null)) return false;
			return x.CompareTo(y) < 0;
		}
		public static bool operator <=(Integer x, Integer y) {
			if (ReferenceEquals(x, y)) return true;
			if (ReferenceEquals(x, null)) return false;
			return x.CompareTo(y) <= 0;
		}

		public static bool operator >(Integer x, Integer y) { return y < x; }
		public static bool operator >=(Integer x, Integer y) { return y <= x; }
		#endregion

		#region Arithmetic
		public static Integer operator -(Integer x) {
			if (x == null) return null;

			return new Integer(x.B, x.A);
		}

		public static Integer operator +(Integer x, Integer y) {
			if (x == null || y == null) return null;
			return new Integer(x.A + y.A, x.B + y.B);
		}
		public static Integer operator -(Integer x, Integer y) { return x + -y; }

		public static Integer operator *(Integer x, Integer y) {
			if (x == null || y == null) return null;
			return new Integer(x.A * y.A + x.B * y.B,
							   x.A * y.B + x.B * y.A);
		}

		public static Integer operator ++(Integer x) { return x + Natural.One; }
		public static Integer operator --(Integer x) { return x - Natural.One; }
		#endregion

		#region Representation
		public bool IsPositive { get { return A > B; } }

		public Natural Magnitude {
			get {
				if (A == B)
					return Natural.Zero;
				if (!IsPositive)
					return (-this).Magnitude;

				Natural result = Natural.Zero;
				for (Natural i = A; i != B; i = i.Previous)
					result++;
				return result;
			}
		}
		#endregion
	}
}
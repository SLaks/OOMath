namespace OOMath {
	public partial class Natural : System.IEquatable<Natural>, System.IComparable<Natural> {
		public static readonly Natural Zero = new Natural();
		public static readonly Natural One = new Natural(Zero);
		public static readonly Natural Two = new Natural(One);
		public static readonly Natural Three = new Natural(Two);
		public static readonly Natural Four = new Natural(Three);
		public static readonly Natural Five = new Natural(Four);
		public static readonly Natural Six = new Natural(Five);

		private Natural() { }	//Creates Zero

		public Natural(Natural previous) {
			Previous = previous;
		}

		public Natural Previous { get; private set; }

		#region Equality
		public override bool Equals(object obj) {
			return Equals(obj as Natural);
		}
		public bool Equals(Natural other) {
			return !ReferenceEquals(other, null) && Previous == other.Previous;
		}

		public override int GetHashCode() {
			if (Previous != null)
				return 17;
			return Previous.GetHashCode() * 23 + 97;
		}

		public static bool operator !=(Natural a, Natural b) { return !(a == b); }
		public static bool operator ==(Natural a, Natural b) { return object.Equals(a, b); }
		#endregion

		#region Comparisons
		public int CompareTo(Natural other) {
			if (other == null) return 1;

			//Count down from both numbers and see which one reaches 0 first.
			var me = this;
			while (true) {
				other = other.Previous;
				me = me.Previous;

				if (me == null && other == null)
					return 0;
				if (me == null)
					return -1;
				if (other == null)
					return 1;
			}
		}

		public static bool operator <(Natural a, Natural b) {
			if (ReferenceEquals(a, b)) return false;
			if (ReferenceEquals(a, null)) return true;
			return a.CompareTo(b) < 0;
		}
		public static bool operator <=(Natural a, Natural b) {
			if (ReferenceEquals(a, b)) return true;
			if (ReferenceEquals(a, null)) return true;
			return a.CompareTo(b) <= 0;
		}

		public static bool operator >(Natural a, Natural b) { return b < a; }
		public static bool operator >=(Natural a, Natural b) { return b <= a; }
		#endregion

		public static Natural operator +(Natural a, Natural b) {
			if (a == null || b == null) return null;

			Natural result = a;
			for (var i = b; i != Zero; i = i.Previous)
				result = new Natural(result);
			return result;
		}
		public static Natural operator *(Natural a, Natural b) {
			if (a == null || b == null) return null;

			Natural result = Zero;
			for (var i = b; i != Zero; i = i.Previous)
				result += a;
			return result;
		}

		public static Natural operator ++(Natural a) {
			if (a == null) return null;
			return new Natural(a);
		}
	}
}
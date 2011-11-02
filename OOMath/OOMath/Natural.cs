namespace OOMath {
	public class Natural : System.IEquatable<Natural> {
		public static readonly Natural Zero = new Natural();
		public static readonly Natural One = new Natural(Zero);
		public static readonly Natural Two = new Natural(One);
		public static readonly Natural Three = new Natural(Two);
		public static readonly Natural Four = new Natural(Three);
		public static readonly Natural Five = new Natural(Four);

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
		public static bool operator <(Natural a, Natural b) {
			if (a == null) return false;
			//Count down from a - 1.  If we meet b on the way, b < a.
			for (var i = a.Previous; i != Zero; i = i.Previous)
				if (i == b)
					return true;
			return false;
		}

		public static bool operator <=(Natural a, Natural b) { return a == b || a < b; }
		public static bool operator >(Natural a, Natural b) { return !(a <= b); }
		public static bool operator >=(Natural a, Natural b) { return !(a < b); }
		#endregion

		public static Natural operator +(Natural a, Natural b) {
			Natural result = a;
			for (var i = b; i != Zero; i = i.Previous)
				result = new Natural(result);
			return result;
		}
	}
}
namespace OOMath {
	public class Natural : System.IEquatable<Natural> {
		public static readonly Natural Zero = new Natural();
		public static readonly Natural One = new Natural(Zero);
		public static readonly Natural Two = new Natural(One);

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
	}
}
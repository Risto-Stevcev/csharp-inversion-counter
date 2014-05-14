using System;

namespace inversioncounter
{
	public static class Sub 
	{
		public static T[] SubArray<T>(this T[] data, int index, int length)
		{
			T[] result = new T[length];
			Array.Copy(data, index, result, 0, length);
			return result;
		}
	}

	public class InversionCounter<T>
	{
		private long inversions;

		public InversionCounter ()
		{
			inversions = 0;
		}

		public T[] mergeAndCount( T[] left, T[] right )
		{
			T[] list = new T[left.Length + right.Length];

			for (int i = 0, l = 0, r = 0; l < left.Length || r < right.Length; i++) {
				if (l < left.Length && r < right.Length) {
					if (System.Collections.Generic.Comparer<T>.Default.Compare (left [l], right [r]) < 0)
						list [i] = left [l++];
					else {
						list [i] = right [r++];
						this.inversions += (left.Length - l);
					}
				} 
				else if (l < left.Length)
					list [i] = left [l++];
				else if (r < right.Length)
					list [i] = right [r++];
			}
			return list;
		}

		public T[] inversionCounter( T[] list )
		{
			if (list.Length == 1)
				return list;

			int mid = list.Length / 2;
			T[] left = inversionCounter (list.SubArray (0, mid));
			T[] right = inversionCounter (list.SubArray (mid, list.Length - mid));

			return mergeAndCount( left, right );
		}

		public long getInversions() {
			return this.inversions;
		}
	}
}


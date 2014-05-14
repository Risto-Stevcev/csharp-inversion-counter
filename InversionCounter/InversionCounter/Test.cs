using NUnit.Framework;
using System;

namespace inversioncounter
{
	[TestFixture ()]
	public class Test
	{
		private InversionCounter<int> ic;

		[SetUp]
		public void SetUp()
		{
			ic = new InversionCounter<int> ();
		}

		[Test ()]
		public void TestMergeAndCount ()
		{
			int[] left = new int[] { 1, 3, 5 };
			int[] right = new int[] { 2, 4, 6 };
			int[] expected = new int[] { 1, 2, 3, 4, 5, 6 };
			CollectionAssert.AreEqual( expected, ic.mergeAndCount(left, right) );
			Assert.AreEqual ( 3, ic.getInversions() );
		}

		[Test ()]
		public void TestInversionCounter ()
		{
			int[] unsorted = new int[] { 1, 21, 4, 8, 7, 15, 3 };
			int[] expected = new int[] { 1, 3, 4, 7, 8, 15, 21 };
			CollectionAssert.AreEqual (expected, ic.inversionCounter (unsorted));
			Assert.AreEqual (10, ic.getInversions ());
		}
	}
}


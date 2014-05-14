using System;
using System.IO;

namespace inversioncounter
{
	public class Run
	{
		static public void Main (string[] args)
		{
			if (args.Length == 2) {
				InversionCounter<int> ic = new InversionCounter<int> ();
				int length = Convert.ToInt32 (args [1]);
				int[] unsorted = new int[length];

				TextReader file = new StreamReader (args [0]);

				for (int i = 0; i < length; i++)
					unsorted [i] = Convert.ToInt32 (file.ReadLine ());

				ic.inversionCounter (unsorted);
				Console.WriteLine (ic.getInversions());
			} else {
				Console.WriteLine ("Usage: ./program [list file] [list length]");
			}
		}
	}
}


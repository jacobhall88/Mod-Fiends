using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class Mathj
	{
		public Mathj ()
		{
		}

		public static float Tan(float f){
			return Mathf.Tan (f * 100 * Mathf.Deg2Rad);
		}
	}
}


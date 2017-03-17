using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMath 
{
	/// <summary>
	/// Multiplies the vectors.
	/// </summary>
	/// <returns>A Vector with the values multiplied</returns>
	/// <param name="a">First vector</param>
	/// <param name="b">Second vector</param>
	public Vector3 MultiplyVectors(Vector3 a, Vector3 b)
	{
		return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
	}

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMath 
{
	public enum dimensions
	{
		x,
		y,
		z,
		none
	}

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
	public Vector3 SetOneVector(Vector3 initial, float newVal, dimensions dimension){
		switch (dimension) {
		case dimensions.x:
			return new Vector3 (newVal, initial.y, initial.z);
		case dimensions.y:
			return new Vector3 (initial.x, newVal, initial.z);
		case dimensions.z:
			return new Vector3 (initial.x, initial.y, newVal);
		case dimensions.none:
		default:
			return initial;
		}
	}
	public float AverageWithTwo(float one, float two){//it's only two vals because i'm too lazy to take in an array
		return (one + two)/2;

	}
	public float DenominateFrac(float numerator, float denominator, float newDenom){
		return numerator * (newDenom / denominator);
	}

}


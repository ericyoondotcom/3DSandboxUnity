using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGen : MonoBehaviour
{
	public GameObject prefab;
	public float deviation;
	public float worldSideSquared = 25;
	public Material dirt;
	EMath emath = new EMath ();
	// Use this for initialization
	void Start ()
	{
		Dictionary<Vector2, float> data = new Dictionary<Vector2, float> ();

		for (int x = 0; x < worldSideSquared; x++) {
			for (int z = 0; z < worldSideSquared; z++) {
				float yval;
				if (x == 0) {
					if (z == 0) {
						yval = 0;
						//first block, yval = 0
					} else {
						yval = data [new Vector2 (x, z - 1)] + Random.Range (-deviation, deviation);
						//in first row, yval = the prev block in that row plus some deviation
					}
				} else {
					if (z == 0) {
						yval = data [new Vector2 (x - 1, z)] + Random.Range (-deviation, deviation);
						//in first column, yval = the prev block in that column plus some deviation
					} else {
						yval = emath.AverageWithTwo (data [new Vector2 (x - 1, z)], data [new Vector2 (x, z - 1)]) + Random.Range (-deviation, deviation);
						//kind of like a def case, so we get the average of the prev block in row and prev block in column plus some deviation
					}
				}
				yval = Mathf.Round (yval);
				if (yval <= 0) {
					yval = 1;
				}
				data.Add (new Vector2 (x, z), yval);
				for (int y = 0; y < yval; y++) {
					GameObject n = (GameObject)Instantiate (prefab, new Vector3 (x, y, z), Quaternion.identity);
					if (y != yval - 1)
						n.GetComponent<MeshRenderer> ().material = dirt;
				}
			}
		}


	}
}
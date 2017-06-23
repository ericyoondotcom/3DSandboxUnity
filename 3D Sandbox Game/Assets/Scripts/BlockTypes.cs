using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTypes : MonoBehaviour {

	public enum blockTypes {
		unknown,
		grass,
		dirt,
		stone,
		coal,
		creeper,
		diamond,
		glass,
		gold,
		iron,
		slime
	}
	public BlockTypes.blockTypes blockType;
}

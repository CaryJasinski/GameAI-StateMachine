using UnityEngine;
using System.Collections;

public sealed class MonoBehaviourInheritor : MonoBehaviour {

	public static Vector3 zeroY(Vector3 v){

		return new Vector3(v.x, 0, v.y);
	}
}

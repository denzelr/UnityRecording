using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	void Update() {
		transform.Rotate(Vector3.forward * Time.deltaTime*60);
	}
}

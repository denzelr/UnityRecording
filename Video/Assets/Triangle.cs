using UnityEngine;
using System.Collections;

public class Triangle : MonoBehaviour {
	void Start() {
		gameObject.AddComponent<MeshFilter>();;
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear();
		mesh.vertices = new Vector3[] {new Vector3(0, 0, 0), new Vector3(-2, 4, 0), new Vector3(2, 4, 0)};
		mesh.uv = new Vector2[] {new Vector2(2, 4), new Vector2(-2, 4), new Vector2(0, 0)};
		mesh.triangles = new int[] {0, 1, 2};
	}

	void Update() {
		transform.Rotate(Vector3.forward * Time.deltaTime*30);
	}
}
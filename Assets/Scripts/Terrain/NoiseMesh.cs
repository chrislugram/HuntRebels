using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class NoiseMesh {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public float power = 3.0f;
	public float scale = 1.0f;

	private Vector2 v2SampleStart = new Vector2(0f, 0f);
	#endregion
	
	#region METHODS_CUSTOM
	public Mesh ApplyNoise(Mesh mesh) {
		v2SampleStart = new Vector2(UnityEngine.Random.Range (0.0f, 100.0f), UnityEngine.Random.Range (0.0f, 100.0f));

		Vector3[] vertices = mesh.vertices;
		for (int i = 0; i < vertices.Length; i++) {    
			float xCoord = v2SampleStart.x + vertices[i].x  * scale;
			float yCoord = v2SampleStart.y + vertices[i].z  * scale;
			vertices[i].y = (Mathf.PerlinNoise (xCoord, yCoord) - 0.5f) * power; 
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();

		return mesh;
	}
	#endregion
}

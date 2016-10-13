using UnityEngine;
using System.Collections;

public class circle : MonoBehaviour {

	public LineRenderer lineRenderer;


	// Use this for initialization
	void Start () {
		lineRenderer = gameObject.AddComponent<LineRenderer>();
	}

	// Update is called once per frame
	void Update () {
		float theta_scale = 0.1f;             //Set lower to add more points
		int size = (int)((2.0f * Mathf.PI) / theta_scale); //Total number of points in circle.

		lineRenderer.SetColors(Color.blue, Color.blue);
		lineRenderer.SetWidth(0.2f, 0.2f);
		lineRenderer.SetVertexCount(size);

		float r = 1f;

		int i = 0;
		int j = 1;
		for(float theta = 0f; theta < 2 * Mathf.PI; theta += 0.1f) {
			float x = transform.position.x + r*Mathf.Cos(theta);
			float y = transform.position.y + r*Mathf.Sin(theta);

			Vector3 pos = new Vector3(x, y, 0);
			lineRenderer.SetPosition(j, pos);
			i+=1;
		}
	}
}
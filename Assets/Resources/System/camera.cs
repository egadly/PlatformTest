using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	Vector3 pos;
	Vector3 shakePos;
	Vector3 desPos;
	GameObject follow;
	public int shakeCounter;

	// Use this for initialization
	void Start () {
		shakeCounter = 0;
		GetComponent<Camera> ().aspect = 16f / 9f;
		follow = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		desPos  = follow.transform.position;
		if (desPos.x != pos.x || pos.y != desPos.y) {
			pos.x -= (pos.x - desPos.x) / 16f;
			pos.y -= (pos.y - desPos.y) / 16f;
		}
		shakePos = pos;
		if (shakeCounter > 0) {
			shakePos.x += Random.Range (-4f, 4f);
			shakePos.y += Random.Range (-4f, 4f);
			shakeCounter--;
		}

		Vector3 intPos = shakePos;
		if ((intPos.x -(float)((int)intPos.x)) > 0.5f)
			intPos.x += 1f;
		if ((intPos.y -(float)((int)intPos.y)) > 0.5f)
			intPos.y += 1f;
		transform.position = shakePos;

	}
}

using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {
	public GameObject light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast(transform.position, Vector3.forward, out hit)) {
			light.transform.position = hit.transform.position;

		}
	}
}

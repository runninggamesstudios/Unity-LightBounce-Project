using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public GameObject light;
	
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		
		if (Physics.Raycast(transform.position, transform.forward, out hit)) {
			light.transform.position = hit.point;

			light.transform.position = light.transform.position + transform.forward * -1;
		}
	
		Debug.DrawRay(transform.position, transform.forward * 100);
	}
}

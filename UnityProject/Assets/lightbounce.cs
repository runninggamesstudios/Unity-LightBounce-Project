using UnityEngine;
using System.Collections;

public class lightbounce : MonoBehaviour {
	private Vector3 angle;
	public GameObject sun;
	public GameObject sunPos;

	public GameObject light;

	private float lightIntTarget;

	private float lightRotY;
	public float lightDistMultiply;
	// Use this for initialization
	void Start () {
		lightIntTarget = 0.09f;
		lightDistMultiply = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Debug.DrawRay(transform.position, -sun.transform.forward * 100);

		light.light.intensity = Mathf.Lerp(light.light.intensity, lightIntTarget, 0.1f);

		if(Physics.Raycast(transform.position, -sun.transform.forward, out hit, 100.0f)){
			if(hit.collider.name == sunPos.gameObject.name){
				lightRotY = light.transform.rotation.y;
				lightRotY = sun.transform.rotation.y;
			
				light.transform.position = transform.position + new Vector3(
					-sun.transform.forward.x * transform.localScale.x * lightDistMultiply,
					0,
					-sun.transform.forward.z * transform.localScale.z * lightDistMultiply);
				//
				lightIntTarget = 0.09f;
			} else {
				lightIntTarget = 0.0f;	
			}
		}
		
	}
}

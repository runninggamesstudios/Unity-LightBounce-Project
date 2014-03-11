using UnityEngine;
using System.Collections;

public class LightBounceScript : MonoBehaviour {
	public GameObject sun;
	public GameObject bounceLight;

	private Vector3 sunAngle;

	private MeshRenderer hitMeshRender;

	private bool rotate;

	private Vector3 sunX;

	private Color targetColor;

	// Use this for initialization
	void Start () {
		rotate = false;
	}
	
	// Update is called once per frame
	void Update () {
		sunAngle = new Vector3(sun.transform.eulerAngles.x, sun.transform.eulerAngles.y, sun.transform.eulerAngles.z);
		transform.rotation = Quaternion.Euler(sunAngle);

		if(targetColor != null){
			bounceLight.light.color = Color.Lerp(bounceLight.light.color, targetColor, 10.0f * Time.deltaTime);
		}

		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f)) {
			hitMeshRender = hit.collider.gameObject.GetComponent<MeshRenderer>();
			//bounceLight.light.color = hitMeshRender.material.color;
			targetColor = hitMeshRender.material.color;
			bounceLight.transform.position = hit.point;

		}
		Debug.DrawRay(transform.position, transform.forward * 100);
		///*
		if(sun.transform.eulerAngles.x > 20.0f  && rotate == false){
			Debug.Log("1");
			sun.transform.Rotate(Vector3.right * 20 * Time.deltaTime);
		} else {
			rotate = true;
			Debug.Log("Tes");
		}

		if(rotate == true){
			sun.transform.Rotate(-Vector3.right * 20 * Time.deltaTime);
			Debug.Log("2");
			if(sun.transform.eulerAngles.x < 20.0f && sun.transform.eulerAngles.y == 0){
				sunX = sun.transform.eulerAngles;
				sun.transform.localEulerAngles = new Vector3(21.0f, 0.0f, 0.0f);
				rotate = false;
			}
		}
		//*/
	}
}

using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour 
{
	public Transform target;
	public float smoothiness = 0.1f;
	public float lookAngle = 70;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 velocity = Vector3.zero;
		Vector3 newPos = Vector3.SmoothDamp (transform.position, target.position, ref velocity, smoothiness);
		float angleV = 0;
		float newAngle = Mathf.SmoothDampAngle (transform.rotation.eulerAngles.y, target.rotation.eulerAngles.y, ref angleV, smoothiness);
		transform.position = newPos;
		transform.rotation = Quaternion.Euler(lookAngle, newAngle, 0);
	}
}

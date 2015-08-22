using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    // Speed of the player
    public float speed = 10f;
    public float rotSpeed = 100f;
    // State of the player. If the player colide with something, set it to true
    private bool collide = false;

	// Use this for initialization
	void Start () {
	        
	}
	
    // Move the player to direction
    // return the newPosition
    public Vector3 move(Vector3 direction)
    {
        print("Test: " + direction);
        transform.Rotate(new Vector3(0, direction.z, 0) * rotSpeed * Time.deltaTime);
        direction.z = 0;
        Vector3 oldPosition = transform.position; // Retreive the old position
        Vector3 newPosition = transform.position + (direction * speed) * Time.deltaTime;

        transform.position = newPosition;

        return newPosition;
    }

    // Update is called once per frame
    void Update () {
        float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		transform.Rotate(new Vector3(0, h, 0) * rotSpeed * Time.deltaTime);
		transform.Translate(0, 0, v * speed * Time.deltaTime, Space.Self );

//
//        Vector3 direction = new Vector3(x, y, z);

//        move(direction);
	}
}

using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    // Speed of the player
    public float speed = 1f;
    public float rotSpeed = 1f;
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
        float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");
        float y = 0;

        Vector3 direction = new Vector3(x, y, z);

        move(direction);
	}
}

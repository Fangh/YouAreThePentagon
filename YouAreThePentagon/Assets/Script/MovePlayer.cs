using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    // Speed of the player
    public float speed = 10f;
    public float rotSpeed = 100f;
    // State of the player. If the player colide with something, set it to true
    private bool collide = false;

	public bool canMove = true;

	// Use this for initialization
	void Start () {
	        
	}
	
    // Move the player to direction
    // return the newPosition
    public void move(Vector3 direction, Vector3 rotation)
    {
		if (!canMove)
			return;

        transform.Rotate(rotation * rotSpeed * Time.deltaTime);
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }

    // Update is called once per frame
    void Update () 
	{
        float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

        move(new Vector3(0, 0, v), new Vector3(0, h, 0));
	}
}

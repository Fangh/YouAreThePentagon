using UnityEngine;
using System.Collections;

public class TriggerAction : MonoBehaviour {

    public Action action;
    public bool active = true;

    private bool playerInTrigger = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (active && playerInTrigger && Input.GetButton("Fire1"))
        {
            action.run(this);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInTrigger = false;
        }
    }
}

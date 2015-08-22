using UnityEngine;
using System.Collections;

public class TriggerAction : MonoBehaviour {

    public Action[] actions;
    public bool active = true;

    private bool playerInTrigger = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (playerInTrigger && Input.GetButton("Fire1"))
        {
            bool allActionInactive = true;
            foreach (Action action in actions)
            {
                action.Launch(this);
                if (action.active)
                    allActionInactive = false;
            }
            if (allActionInactive)
                active = false;
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

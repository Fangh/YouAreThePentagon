using UnityEngine;
using System.Collections;

public class TriggerAction : MonoBehaviour {

    public Action[] actions;
    public bool active = true;
    public float actionInterval = 0.6f;

    private bool playerInTrigger = false;
    private float accumulatorInterval = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        accumulatorInterval -= Time.deltaTime;
	    if (playerInTrigger && Input.GetButton("Fire1") && accumulatorInterval <= 0.1f)
		{
            bool allActionInactive = true;
            foreach (Action action in actions)
			{
				if(GetComponent<Animator>())
					GetComponent<Animator>().SetTrigger("Go");
                action.Launch(this);
                if (action.active)
                    allActionInactive = false;
            }
            if (allActionInactive)
                active = false;
            accumulatorInterval = actionInterval;
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

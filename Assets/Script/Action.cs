using System;
using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour {

    public bool desactiveAfter = true;
    public bool active = true;
    public float probability = 1.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reactivate()
    {
        active = true;
    }

    public void Launch(TriggerAction trigger = null)
    {
        float r = (float)Math.Round(UnityEngine.Random.Range(0.0f, 1.0f), 1);
        print("Try to do action with probability: " + r + ", prob " + probability + ", activate ? " + (r <= probability));
        if (active && r <= probability)
        {
            if (desactiveAfter)
                active = false;
            Run(trigger);
        }
    }

    abstract public void Run(TriggerAction trigger = null);
}

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
        if (active && Random.Range(0.0f, 1.0f) <= probability)
            Run(trigger);
        if (desactiveAfter)
            active = false;
    }

    abstract public void Run(TriggerAction trigger = null);
}

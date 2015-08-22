using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour {

    public bool desactiveAfter = true;
    public bool active = true;
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
        if (active)
            Run(trigger);
        if (desactiveAfter)
            active = false;
    }

    abstract public void Run(TriggerAction trigger = null);
}

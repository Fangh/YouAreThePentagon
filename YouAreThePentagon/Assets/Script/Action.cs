using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    abstract public void run(TriggerAction trigger = null);
}

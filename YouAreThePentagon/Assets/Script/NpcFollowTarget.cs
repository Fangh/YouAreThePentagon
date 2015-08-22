using System;
using UnityEngine;
using System.Collections;

public class NpcFollowTarget : MonoBehaviour
{
    public float ValidDistance;
    private GameObject[] _targets;
    private GameObject _actualTarget;
    private NPCBehavior _behavior;
	// Use this for initialization
	void Start ()
	{
	    _targets = GameObject.FindGameObjectsWithTag("NPCTarget");
	    _behavior = gameObject.GetComponent<NPCBehavior>();
	    _actualTarget = GetNextTarget();
	}

    private GameObject GetNextTarget()
    {
        int i = (int)Math.Round(UnityEngine.Random.Range(0.0f, (float)(_targets.Length - 1)), 0);
        print("Go to target " + i);
        print("Nb target : " + _targets.Length);
        return _targets[i];
    }
	
	// Update is called once per frame
	void Update () {
	    if (Vector3.Distance(transform.position, _actualTarget.transform.position) <= ValidDistance)
	    {
	        _actualTarget = GetNextTarget();
	    }
	    _behavior.target = _actualTarget.transform;
	}
}

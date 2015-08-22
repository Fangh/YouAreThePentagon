using System;
using UnityEngine;
using System.Collections;

public class NpcFollowTarget : MonoBehaviour
{
    public float ValidDistance;
    public float LowBoundWaitTime = 2f;
    public float HighBoundWaitTime = 10f;

    private GameObject[] _targets;
    private GameObject _actualTarget;
    private NPCBehavior _behavior;
    private float _accumulator = 0.0f;
    private bool _reachTarget;
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
	void Update ()
	{
	    _accumulator -= Time.deltaTime;
	    if (_accumulator < 0f)
	        _accumulator = 0f;
	    if (!_reachTarget && Vector3.Distance(transform.position, _actualTarget.transform.position) <= ValidDistance)
	    {
	        _reachTarget = true;
	        _accumulator = UnityEngine.Random.Range(LowBoundWaitTime, HighBoundWaitTime);
	    }
	    if (_reachTarget && Math.Abs(_accumulator) < 0.1f)
	    {
	        _reachTarget = false;
	        _actualTarget = GetNextTarget();
	    }
	    _behavior.target = _actualTarget.transform;
	}
}

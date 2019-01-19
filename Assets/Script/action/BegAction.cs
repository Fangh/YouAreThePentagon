using UnityEngine;
using System.Collections;

public class BegAction : AddMoney
{

    private bool _playerInTrigger = false;
	// Use this for initialization
	void Start () {
        if (!money)
        {
            money = GameObject.FindGameObjectWithTag("Player").GetComponent<Money>();
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public override void Run(TriggerAction trigger)
    {
        if (trigger == null)
            base.Run(trigger);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "NPC" && _playerInTrigger)
        {
            base.Launch(null);
        }
        if (collider.gameObject.tag == "Player")
        {
            _playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            _playerInTrigger = false;
        }
    }
}

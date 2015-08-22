using UnityEngine;
using System.Collections;

public class AddMoney : Action {

    public int amount = 5;
    public Money money;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    override public void Run(TriggerAction trigger)
    {
        money.addMoney(amount);
    }
}

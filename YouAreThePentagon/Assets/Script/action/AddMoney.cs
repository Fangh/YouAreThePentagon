﻿using UnityEngine;
using System.Collections;

public class AddMoney : Action {

    public int amount = 5;
    public Money money;
    public bool desactiveAfter = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    override public void run(TriggerAction trigger)
    {
        money.addMoney(amount);
        if (desactiveAfter && trigger != null)
            trigger.active = false;
    }
}
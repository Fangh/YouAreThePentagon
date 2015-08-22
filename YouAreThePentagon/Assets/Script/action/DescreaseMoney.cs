using UnityEngine;
using System.Collections;

public class DescreaseMoney : Action {

    public int amount = 5;
    public Money money;

    // Use this for initialization
    void Start()
	{
		if (!money)
			money = GameObject.FindGameObjectWithTag ("Player").GetComponent<Money>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Run(TriggerAction trigger)
    {
        money.decreaseMoney(amount);
    }
}

using UnityEngine;
using System.Collections;

public class Money : DisplayedValue {

    public int money = 10;
    public int maxMoney = 6000;
    public float decreaseRate = 2;
    public int decreaseAmount = 1;

    private float accumulator = 0.0f;
	// Use this for initialization
	void Start () {
	}

    override public int value()
    {
        return money;
    }
	
    public int addMoney(int amount)
    {
        money += amount;
        if (money > maxMoney)
            money = maxMoney;
        return money;
    }

    public int decreaseMoney(int amount)
    {
        money -= amount;
        if (money < 0)
            money = 0;
        return money;
    }

    private void periodicDecrease()
    {
        accumulator += Time.deltaTime;
        if (accumulator >= decreaseRate)
        {
            decreaseMoney(decreaseAmount);
            accumulator = 0f;
        }
    }

	// Update is called once per frame
	void Update () {
        periodicDecrease();
	}
}

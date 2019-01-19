using UnityEngine;
using System.Collections;

public class Money : DisplayedValue {

    public int money = 10;
    public int maxMoney = 6000;
    public float decreaseRate = 2;
    public int decreaseAmount = 1;
    public float modificationIntervalTime = 0.6f;

    private float accumulator = 0.0f;
    private float accumulatorIntervalTime = 0.0f;
    // Use this for initialization
    void Start () {
	}

    override public int value()
    {
        return money;
    }
	
    public int addMoney(int amount)
    {
        if (accumulatorIntervalTime > 0.1f)
            return money;
        money += amount;
        if (money > maxMoney)
            money = maxMoney;
        accumulatorIntervalTime = modificationIntervalTime;
        return money;
    }

    public int decreaseMoney(int amount)
    {
        print(accumulatorIntervalTime);
        if (accumulatorIntervalTime > 0.1f)
            return money;
        money -= amount;
        if (money < 0)
            money = 0;
        accumulatorIntervalTime = modificationIntervalTime;
        return money;
    }

    private void periodicDecrease()
    {
        accumulator += Time.deltaTime;
        if (decreaseRate > 0f && accumulator >= decreaseRate)
        {
            decreaseMoney(decreaseAmount);
            accumulator = 0f;
        }
    }

	// Update is called once per frame
	void Update () {
        periodicDecrease();
        accumulatorIntervalTime -= Time.deltaTime;
        if (accumulatorIntervalTime < 0f)
            accumulatorIntervalTime = 0f;
    }
}

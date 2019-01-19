using UnityEngine;
using System.Collections;

public class Life : DisplayedValue {

    public int life = 10;
    public int maxLife = 15;
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
        return life;
    }

    public void hit(int damage)
    {
        if (accumulatorIntervalTime > 0)
            return;
        life -= damage;
        if (life < 0)
            life = 0;
        accumulatorIntervalTime = modificationIntervalTime;
    }

    public void heal(int heal)
    {
        if (accumulatorIntervalTime > 0)
            return;
        life += heal;
        if (life > maxLife)
            life = maxLife;
        accumulatorIntervalTime = modificationIntervalTime;
    }

    private void periodicDecrease()
    {
        accumulator += Time.deltaTime;
        if (decreaseRate > 0f && accumulator >= decreaseRate)
        {
            hit(decreaseAmount);
            accumulator = 0f;
        }
    }

    // Update is called once per frame
    void Update () {
        periodicDecrease();
        accumulatorIntervalTime -= Time.deltaTime;
        if (accumulatorIntervalTime < 0f)
            accumulatorIntervalTime = 0;
	}
}

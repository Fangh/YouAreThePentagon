using UnityEngine;
using System.Collections;

public class Life : DisplayedValue {

    public int life = 10;
    public int maxLife = 10;
    public float decreaseRate = 2;
    public int decreaseAmount = 1;

    private float accumulator = 0.0f;
    // Use this for initialization
    void Start () {
	
	}

    override public int value()
    {
        return life;
    }

    void hit(int damage)
    {
        life -= damage;
        if (life < 0)
            life = 0;
    }

    void heal(int heal)
    {
        life += heal;
        if (life > maxLife)
            life = maxLife;
    }

    private void periodicDecrease()
    {
        accumulator += Time.deltaTime;
        if (accumulator >= decreaseRate)
        {
            hit(decreaseAmount);
            accumulator = 0f;
        }
    }

    // Update is called once per frame
    void Update () {
        periodicDecrease();
	}
}

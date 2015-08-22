using UnityEngine;
using System.Collections;

public class DescreaseLife : Action {

    public int amount = 5;
    public Life life;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Run(TriggerAction trigger)
    {
        life.hit(amount);
    }
}

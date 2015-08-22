using UnityEngine;
using System.Collections;

public class DescreaseLife : Action {

    public int amount = 5;
    public Life life;
    public bool desactiveAfter = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void run(TriggerAction trigger)
    {
        life.hit(amount);
        if (desactiveAfter && trigger != null)
            trigger.active = false;
    }
}

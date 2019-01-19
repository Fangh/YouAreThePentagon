using System;
using UnityEngine;
using System.Collections;

public class RandomNpcDialog : MonoBehaviour
{

    public static DialogAction[] PossibleDialog;
    public int Probability;

    public DialogAction Dialog;

    private MovePlayer _movePlayer;
	// Use this for initialization
	void Start () {
	    if (PossibleDialog == null)
	    {
            print("Dialog : " + GameObject.FindGameObjectWithTag("Dialog").tag);
            PossibleDialog = GameObject.FindGameObjectWithTag("Dialog").GetComponents<DialogAction>();
            print("Possible :" + PossibleDialog);
	    }
	    if (!Dialog)
	    {
            print("Select Dialog");
	        int r = (int)Math.Round(UnityEngine.Random.Range(0f, (float) PossibleDialog.Length-1));
	        Dialog = PossibleDialog[r];
	    }
	    _movePlayer = GameObject.FindWithTag("Player").GetComponent<MovePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("Fire1") && Dialog.IsRunning())
	    {
	        Dialog.Run(null);
	    }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (UnityEngine.Random.Range(0, 100) < Probability)
            {
                Dialog.Run(null);
                _movePlayer.canMove = true;
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Dialog.Run(null);
            _movePlayer.canMove = true;
        }
    }
}

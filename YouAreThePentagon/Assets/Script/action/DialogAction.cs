using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogAction : Action
{
	public bool question;
	public GameObject dialogPanel;
	public string characterName;
	[TextArea(3,10)]
	public string text;


	bool isRunning = false;
    private Tweener textTween;

	// Use this for initialization
	void Start ()
	{
		if (!dialogPanel)
        {
            dialogPanel = GameObject.FindGameObjectWithTag("DialogPanel");
        }
        dialogPanel.transform.GetChild(0).gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () 
	{

	}

	override public void Run(TriggerAction trigger)
	{
        if (isRunning)
        {
            Stop();
            return;
        }
		isRunning = true;
		GameObject.FindWithTag ("Player").GetComponent<MovePlayer>().canMove = false;
		dialogPanel.transform.GetChild (0).gameObject.SetActive (true);
		dialogPanel.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = characterName;
		textTween = dialogPanel.transform.GetChild (0).GetChild (1).GetComponent<Text> ().DOText (
			text, 2f, true, ScrambleMode.None, null);

		if(question)
			dialogPanel.transform.GetChild (1).gameObject.SetActive (true);

		if (desactiveAfter)
			active = true;
	}

	void Stop()
	{
		isRunning = false;
        textTween.Kill();
		GameObject.FindWithTag ("Player").GetComponent<MovePlayer>().canMove = true;
		dialogPanel.transform.GetChild (0).gameObject.SetActive (false);
		dialogPanel.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = "";
		dialogPanel.transform.GetChild (0).GetChild (1).GetComponent<Text> ().text = "";

		if(question)
			dialogPanel.transform.GetChild (1).gameObject.SetActive (false);
	}
}

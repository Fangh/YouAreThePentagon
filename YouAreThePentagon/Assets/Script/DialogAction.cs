using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class DialogAction : MonoBehaviour 
{
	public GameObject dialogPanel;
	public string characterName;
	[TextArea(3,10)]
	public string text;
	Tweener textTween;

	bool isRunning = false;

	// Use this for initialization
	void Start () 
	{
		if (!dialogPanel)
			dialogPanel = GameObject.FindGameObjectWithTag ("DialogPanel");
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.Space) && !isRunning)
			Run ();
		else if (Input.GetKeyUp (KeyCode.Space) && isRunning)
			Stop ();
	
	}

	void Run()
	{
		isRunning = true;
		GameObject.FindWithTag ("Player").GetComponent<MovePlayer>().canMove = false;
		dialogPanel.transform.GetChild (0).gameObject.SetActive (true);
		dialogPanel.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = characterName;
		textTween = dialogPanel.transform.GetChild (0).GetChild (1).GetComponent<Text> ().DOText (
			text, 2f, true, ScrambleMode.None, null);
	}

	void Stop()
	{
		isRunning = false;
		textTween.Kill ();
		GameObject.FindWithTag ("Player").GetComponent<MovePlayer>().canMove = true;
		dialogPanel.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = "";
		dialogPanel.transform.GetChild (0).GetChild (1).GetComponent<Text> ().text = "";
		dialogPanel.transform.GetChild (0).gameObject.SetActive (false);
	}
}

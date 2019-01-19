using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class YesNoQuestion : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void TurnBlack()
	{
		GetComponent<Text> ().color = Color.black;
	}
	public void TurnWhite()
	{
		GetComponent<Text> ().color = Color.white;
	}

	public void OnClick()
	{
		transform.DOShakeScale (0.5f, 0.1f, 1, 0);
	}
}

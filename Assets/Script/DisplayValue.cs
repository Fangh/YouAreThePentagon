using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayValue : MonoBehaviour {

    // Value to Display
    public DisplayedValue value;
    public Text text;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponentInParent<Text>();
        print(text);
	}
	
	// Update is called once per frame
	void Update () {
        text.text = value.value().ToString();
	}
}

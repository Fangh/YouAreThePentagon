using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayInteractionPopup : MonoBehaviour {

    public SpriteRenderer popup;
    public float transitionSpeed = 1f;

    private Color normalColor;
    private Color targetColor;

	// Use this for initialization
	void Start () {
        normalColor = popup.color;
        popup.color = new Color(normalColor.r, normalColor.g, normalColor.b, 0);
	}

    private void setInvisible()
    {
        targetColor = new Color(normalColor.r, normalColor.g, normalColor.b, 0);
    }

    private void setVisible()
    {
        targetColor = new Color(normalColor.r, normalColor.g, normalColor.b, 1);
    }
	
	// Update is called once per frame
	void Update () {
        popup.color = Color.Lerp(popup.color, targetColor, transitionSpeed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Player enter in trigger");
            setVisible();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            setInvisible();
        }
    }
}

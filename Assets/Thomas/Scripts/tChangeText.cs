using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tChangeText : MonoBehaviour
{
    private Text buttonText;
	// Use this for initialization
    void Awake()
    {
        buttonText = GetComponent<Text>();
        buttonText.text = "Button";
    }
	public void tButtonText01 ()
    {
        buttonText.text = "0001";
	}
    public void tButtonText02()
    {
        buttonText.text = "Cube";
    }

    // Update is called once per frame
    void Update () {
	
	}
}

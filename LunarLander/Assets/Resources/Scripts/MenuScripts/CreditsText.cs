using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsText : MonoBehaviour {

    Text creditsText;
    TextAsset credits;
    private float velocity = 4f;

    Vector3 initialPos;

	// Use this for initialization
	void Start () {

        credits = Resources.Load("Text/Credits") as TextAsset;
        creditsText = GetComponent<Text>();

        creditsText.text = credits.text;

        initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.up * Time.deltaTime * velocity);

	}

    void OnDisable()
    {
        transform.position = initialPos;
    }
}

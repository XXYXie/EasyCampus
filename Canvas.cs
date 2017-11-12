using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Canvas : MonoBehaviour {
    TextMesh text;
    public float letterPause = 0.00001f;
    string msg = "";
    TextMesh textdrama;
    TextMesh texthunt;
    TextMesh textart;
    // Use this for initialization
    void Start () {
        textdrama = GameObject.Find("Canvas/DramaText").GetComponent<TextMesh>();
        texthunt = GameObject.Find("Canvas/HuntText").GetComponent<TextMesh>();
        textart = GameObject.Find("Canvas/ArtText").GetComponent<TextMesh>();
        texthunt.gameObject.SetActive(false);
        textdrama.gameObject.SetActive(false);
        textart.gameObject.SetActive(false);
    }
    IEnumerator Type()
    {
        foreach (char letter in msg.ToCharArray())
        {
            text.text += letter;
            if (text.text == msg)
            {
                text.text = "";
            }
            yield return new WaitForSeconds(letterPause);
        }
    }
    // Update is called once per frame
    void Update()
    {
        string nearest = GameObject.Find("First Person Controller").GetComponent<Move>().getNearestBuilding();
        if (nearest != null && Input.GetKeyDown("i"))
        {
            if (nearest == "Drama")
            {
                text = textdrama;
                textdrama.gameObject.SetActive(true);
            }
            else if (nearest == "Hunt Library")
            {
                text = texthunt;
                texthunt.gameObject.SetActive(true);
            }
            else if (nearest == "CFA")
            {
                text = textart;
                textart.gameObject.SetActive(true);
            }
            msg = text.text;
            text.text = "";
            StartCoroutine(Type());
        }
    }
}
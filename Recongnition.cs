using System.Collections;
using System.Linq;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class Recongnition : MonoBehaviour {
    KeywordRecognizer keywordrecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	public float timing = 0;
	public bool test = false;
    
	public bool drama = false;
	public bool sports = false;
	public bool hunt = false;
	public bool cfa = false;
	public bool hamerschlag = false;
	public bool stop = false;
	public List<Dictionary<string,object>> data = new List<Dictionary<string, object>>();
	public bool dataTest = false;

    CharacterController controller;
    Move move;

    // Use this for initialization

    void Start() {

        controller = GetComponent<CharacterController>();
        move = controller.GetComponent<Move>();
		keywords.Add("start", () => {
			//data = CSVReader.Read ("unityTest.csv");
			dataTest=true;
		}); 
		
        keywords.Add("up", () =>
            {
				test = true;
            });
		keywords.Add("go to drama", () =>
			{
				drama = true;
			});
		keywords.Add("go to sports field", () =>
			{
				sports = true;
			});
        keywords.Add("go to hunt", () =>
        {
				hunt = true;
        });
        keywords.Add("go to CFA", () =>
        {
				cfa = true;
        });
        keywords.Add("go to Hamerschlag", () =>
        {
				hamerschlag = true;
        });
        keywords.Add("sixteen one hundred", () =>
        {
				hunt = true;
        });
        keywords.Add("critical theories in art", () =>
        {
				cfa = true;
        });
        keywords.Add("do some sports", () =>
        {
				sports = true;
        });
		keywords.Add("go to functional programming class", () =>
			{
				hamerschlag = true;
			});
        keywords.Add("stop", () =>
        {
            stop = true;
        });

        keywordrecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordrecognizer.OnPhraseRecognized += keywordrecognizeronphraserecoginized;
        keywordrecognizer.Start();




    }
	
    void keywordrecognizeronphraserecoginized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

	// Update is called once per frame
	void Update () {
		if (dataTest) {
            //Debug.Log("call success");
			//Debug.Log(data[0]["Course Number"]);
			dataTest = false;
		}
        if (test)
        {
            //Debug.Log("Hear test");
            test = false;
        }
        if (drama)
        {
            move.destination = 3;
            drama = false;
        }
        if (sports)
        {
            move.destination = 16;
            sports = false;
        }
        if (hamerschlag)
        {
            move.destination = 22;
            hamerschlag = false;
        }
        if (cfa)
        {
            move.destination = 11;
            cfa = false;
        }
        if (hunt)
        {
            move.destination = 9;
            hunt = false;
        }
        if (stop)
        {
            move.stop();
            stop = false;
        }
		
	}
}
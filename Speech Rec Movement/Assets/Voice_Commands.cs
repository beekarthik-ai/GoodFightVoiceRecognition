using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Voice_Commands : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private int _attackCount = 0;
    private void Start()
    {
        actions.Add("left", Left);
        actions.Add("right", Right);
        actions.Add("mid", Mid);
        actions.Add("attack", Attack);
        actions.Add("tack", Attack);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
        transform.position = new Vector3(0, 0, 0);
    }

    private void Left()
    {
        /**Go to the left*/
        transform.Translate(1, 0, 0);
        //transform.position = new Vector3(5, 0, 0);
    }

    private void Right()
    {
        /**Go to the right*/
        transform.Translate(-1, 0, 0);
        //transform.position = new Vector3(-5, 0, 0);
    }

    private void Mid()
    {
        /**Go to the middle*/
        transform.Translate(-1, 0, 0);
        //transform.position = new Vector3(0, 0, 0);
    }

    private void Attack()
    {
        /**This is just filler for us to add an attack*
         * it alternates beteen making the thing go up or down
         * */
        if (_attackCount % 2 != 0)
        {
            transform.Translate(0, 1, 0);
        }
        else 
        {
            transform.Translate(0, -1, 0);
        }
        _attackCount += 1;
    }

}

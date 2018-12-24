using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    private ModalPanel modalPanel;

    void Awake ()
    {
        modalPanel = ModalPanel.Instance ();
    }

	// Use this for initialization
	void Start () {
        //modalPanel.dieThrowDialog ("Die Throw", "Do you want the computer to throw the dice, or fill the result in yourself ?", yes_event, cancel_event, dieEvent, 1, 10);
        modalPanel.dieThrowDialog ("Throw a dice.", "Do you want the computer to throw the dice? If not, please fill in your own result.", yes_event, cancel_event, dieEvent, options_event, 2, 6);
        //modalPanel.anouncement ("Hey There.", "I have got here with me a pretty long text that surely will be too long to fit in the space reserved for text in the Modal Panel. But, actually it is not. So i'll just BlaBlubb BlaBlah Oh Yeah UHuH. BlaBlubb BlaBlah Oh Yeah UHuH. BlaBlubb BlaBlah Oh Yeah UHuH.");
    }

    void yes_event ()
    {
        print ("yes");
        int result = (Random.Range (1, 10));
        print (result);
    }

    void no_event ()
    {
        print ("no");
    }

    void cancel_event ()
    {
        print ("cancel");
    }

    void options_event ()
    {
        print ("options");
    }

    void dieEvent (string str)
    {
        print ("received: " + str);
    }
}

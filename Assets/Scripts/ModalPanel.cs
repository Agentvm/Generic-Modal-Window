using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

    public Text header_text;
    public Text question_text;
    public Button yes_button;
    public Button okay_button;
    public Button no_button;
    public Button cancel_button;
    public InputField die_input_field;
    public Button options_button;
    public GameObject modal_panel_object;

    private static ModalPanel modalPanel;
    public static ModalPanel Instance ()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType (typeof (ModalPanel)) as ModalPanel;
            if ( !modalPanel )
                Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }
        return modalPanel;
    }

    /// <summary>
    /// Buttons: okay
    /// </summary>
    public void anouncement ( string header, string anouncement )
    {
        modal_panel_object.SetActive (true);
        deactivateAllElements ();

        // setup buttons
        setupOkayButton ();

        // set texts
        this.header_text.text = header;
        this.question_text.text = anouncement;

    }

    /// <summary>
    /// Buttons: Yes/No
    /// </summary>
    public void question ( string header, string question, UnityAction yesEvent, UnityAction noEvent )
    {
        modal_panel_object.SetActive (true);
        deactivateAllElements ();

        // setup buttons
        setupYesButton (yesEvent);
        setupNoButton (noEvent);

        // set texts
        this.header_text.text = header;
        this.question_text.text = question;

    }

    /// <summary>
    /// Buttons: yes/cancel/custom
    /// </summary>
    public void dieThrowDialog ( string header, string question, UnityAction yesEvent, UnityAction cancelEvent, UnityAction<string> dieEvent, int die_throws = 1, int die_size = 100 )
    {
        modal_panel_object.SetActive (true);
        deactivateAllElements ();

        // re-activate respective buttons
        setupYesButton (yesEvent);
        //setupNoButton (noEvent);
        setupCancelButton (cancelEvent);
        setupDiePanel (dieEvent);
        //setupOptionsButton (optionsEvent);

        // set texts
        this.header_text.text = header;
        this.question_text.text = question;
        this.die_input_field.placeholder.GetComponent<Text> ().text = die_throws + "d" + die_size;

    }

    /// <summary>
    /// Buttons: yes/cancel/custom/options
    /// </summary>
    public void dieThrowDialog ( string header, string question, UnityAction yesEvent, UnityAction cancelEvent, UnityAction<string> dieEvent, UnityAction optionsEvent, int die_throws = 1, int die_size = 100 )
    {
        modal_panel_object.SetActive (true);
        deactivateAllElements ();

        // re-activate respective buttons
        setupYesButton (yesEvent);
        //setupNoButton (noEvent);
        setupCancelButton (cancelEvent);
        setupDiePanel (dieEvent);
        setupOptionsButton (optionsEvent);

        // set texts
        this.header_text.text = header;
        this.question_text.text = question;
        this.die_input_field.placeholder.GetComponent<Text> ().text = die_throws + "d" + die_size;

    }

    /*public void dieThrowDialog ( string header, string question, UnityAction yesEvent, UnityAction noEvent,
                                                    UnityAction cancelEvent, UnityAction<string> dieEvent,
                                                    UnityAction optionsEvent, int die_throws = 1, int die_size = 100 )
    {
        modal_panel_object.SetActive (true);
        deactivateAllElements ();

        // re-activate respective buttons
        setupYesButton (yesEvent);
        setupNoButton (noEvent);
        setupCancelButton (cancelEvent);
        setupDiePanel (dieEvent);
        setupOptionsButton (optionsEvent);

        // set texts
        this.header_text.text = header;
        this.question_text.text = question;
        this.die_input_field.placeholder.GetComponent<Text> ().text = die_throws + "d" + die_size;

    }*/

    void setupYesButton ( UnityAction button_event )
    {
        yes_button.gameObject.SetActive (true);
        yes_button.onClick.RemoveAllListeners ();
        yes_button.onClick.AddListener (button_event);
        yes_button.onClick.AddListener (closePanel);
    }

    void setupOkayButton ( )
    {
        okay_button.gameObject.SetActive (true);
        okay_button.onClick.RemoveAllListeners ();
        okay_button.onClick.AddListener (closePanel);
    }

    void setupNoButton ( UnityAction button_event )
    {
        no_button.gameObject.SetActive (true);
        no_button.onClick.RemoveAllListeners ();
        no_button.onClick.AddListener (button_event);
        no_button.onClick.AddListener (closePanel);
    }

    void setupCancelButton ( UnityAction button_event )
    {
        cancel_button.gameObject.SetActive (true);
        cancel_button.onClick.RemoveAllListeners ();
        cancel_button.onClick.AddListener (button_event);
        cancel_button.onClick.AddListener (closePanel);
    }

    void setupOptionsButton ( UnityAction button_event )
    {
        options_button.gameObject.SetActive (true);
        options_button.onClick.RemoveAllListeners ();
        options_button.onClick.AddListener (button_event);
        options_button.onClick.AddListener (closePanel);
    }

    void setupDiePanel ( UnityAction<string> edit_event )
    {
        die_input_field.transform.parent.gameObject.SetActive (true);
        die_input_field.onEndEdit.RemoveAllListeners ();
        die_input_field.onEndEdit.AddListener (edit_event);
        //field.OnSubmit (closePanel);
    }

    /// <summary>
    /// Deactivate the clickable elements
    /// </summary>
    void deactivateAllElements ()
    {
        yes_button.gameObject.SetActive (false);
        okay_button.gameObject.SetActive (false);
        no_button.gameObject.SetActive (false);
        cancel_button.gameObject.SetActive (false);
        die_input_field.transform.parent.gameObject.SetActive (false);
        options_button.gameObject.SetActive (false);
}

    public void closePanel ()
    {
        modal_panel_object.SetActive (false);
    }


}

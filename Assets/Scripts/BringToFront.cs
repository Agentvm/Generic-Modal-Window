using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour {
    
    void Awake ()
    {
        gameObject.SetActive (false);
    }

	void OnEnable ()
    {
        transform.SetAsLastSibling ();
	}
}

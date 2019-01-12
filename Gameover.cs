using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour {

	private static String message;
    public Text messageLabel;

    public static void setMessage(String newMessage){
		message=newMessage;
	}

	// Use this for initialization
	void Start () {
        messageLabel.text = "" + message;
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCReceiver : MonoBehaviour {

	public string RemoteIP = "127.0.0.1";
	public int SendToPort = 6448;
	public int ListenerPort = 12000;
	public Transform controller;

	private Osc handler;
	private int sig1 = 0;
	private int sig2 = 0;

	// Use this for initialization
	void Start () {
		//Initializes on start up to listen for messages
		//make sure this game object has both UDPPackIO and OSC script attached

		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(RemoteIP, SendToPort, ListenerPort);
		handler = GetComponent<Osc>();
		handler.init(udp);


		//Tell Unity to call function Example1 when message /wek/outputs arrives
		handler.SetAddressHandler("/wek/outputs", Example1);
		Debug.Log("OSC Running");
	}

	
	// Update is called once per frame
	void Update () {
		GameObject hand = GameObject.FindGameObjectWithTag("RightHand");

		if (Input.GetKeyDown (KeyCode.Alpha1)){
			hand.transform.Rotate (0, sig1, sig2);
			Debug.Log( "1 key was pressed." );}
	}

	public void Example1(OscMessage oscMessage ){
		Debug.Log("Called Example One > " + Osc.OscMessageToString(oscMessage));
		Debug.Log("Message Values > " + oscMessage.Values[0] + " " + oscMessage.Values[1]);
//		sig1 = oscMessage.Values[0];
//		sig2 = oscMessage.Values[1];
	}
}

using UnityEngine;
using System.Collections;
using SocketIO;

public class ObjectMoving : MonoBehaviour {
	SocketIOComponent socket;

	// Use this for initialization
	void Start () {
		//ws://localhost:4567/socket.io/?EIO=4&transport=websocket
		//GameObject go = GameObject.Find("SocketIO");
		socket = GameObject.FindObjectOfType<SocketIOComponent>();
		//socket.Connect ();

		socket.On("open", OnSocketOpen);
		socket.On("error", OnSocketError);
		socket.On("chat message", ChatMessage);

		//StartCoroutine(TestCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSocketOpen(SocketIOEvent e){
		this.LogMessage("socket open", e);
	}

	public void OnSocketError(SocketIOEvent e){
		this.LogMessage("socket error", e);
	}

	public void ChatMessage(SocketIOEvent e){
		this.LogMessage("socket message", e);
	}

	public void LogMessage(string state, SocketIOEvent e) {
		string datetime = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"); 
		Debug.Log("[" + datetime + "][" + state + "][" + socket.sid + "] " + e.name + " " + e.data);
	}

	IEnumerator TestCoroutine()
	{
		while(true)
		{
			yield return null;
			Debug.Log(Time.deltaTime);
		}
	}
}

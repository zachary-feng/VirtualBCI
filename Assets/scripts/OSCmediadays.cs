using UnityEngine;
using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using VVVV_OSC;

public class OSCmediadays : MonoBehaviour {

	private Thread thread;
	private OSCReceiver oscin;

	private int signal = 0;

	void Start () {
		oscin = new OSCReceiver(12345);
		thread = new Thread( new ThreadStart( UpdateOSC ) );
		thread.Start();
	}

	void OnApplicationQuit() {
		oscin.Close ();
		thread.Interrupt ();
		if( !thread.Join(2000) ) {
			thread.Abort();
		}
	}

	void UpdateOSC() {
		while( true ) {
			OSCPacket msg = oscin.Receive ();
			if ( msg != null ) {
				if ( msg.IsBundle() ) {
					//Debug.Log ("msg is bundle");
					OSCBundle b = (OSCBundle) msg;
					foreach( OSCPacket subm in b.Values ) {
						parseMessage( subm );
					}
				} else {
//					Debug.Log ("msg is singular");
					parseMessage( msg );
				}
			}
			//Debug.Log("while loop works");
			// Thread.Sleep( 5 );
		}
	}

	void parseMessage( OSCPacket msg ) {
		Debug.Log( "value: " + (int) msg.Values[0] );

		signal =(int) msg.Values [0];

	}

	void Update() {
		//UpdateOSC();
		if((int) signal == 7) {
			transform.Rotate (Vector3.down * Time.deltaTime * 100);
		} else {
			transform.Rotate (Vector3.up * Time.deltaTime * 100);
		}


	}
}

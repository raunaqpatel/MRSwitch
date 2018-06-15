using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightONOFF : MonoBehaviour {

	// Use this for initialization
	SpacebrewEvents sbEvents;
	GameObject light;

	void Start () {
		GameObject go = GameObject.Find ("SpacebrewObject");
		sbEvents = go.GetComponent <SpacebrewEvents> ();
		light = GameObject.Find("ScaryImage/InnerDetails/node_Hypercolor_e8ef32b1-baa8-460a-9c2c-9cf8506794f5_0_0");
		StartCoroutine(timeFunctionforLightOnOff());
	}

    private IEnumerator timeFunctionforLightOnOff()
    {
        while(true){
			// sbEvents.sendMessageOverSpaceBrew("buttonPress","boolean","true");	
			// yield return new WaitForSecondsRealtime(0.1f);
			// sbEvents.sendMessageOverSpaceBrew("buttonPress","boolean","true");	
			// light.GetComponent<Renderer>().enabled = true;
			// yield return new WaitForSecondsRealtime(0.1f);

			// sbEvents.sendMessageOverSpaceBrew("buttonPress","boolean","false");
			// light.GetComponent<Renderer>().enabled = false;
			// yield return new WaitForSecondsRealtime(0.1f);

			// sbEvents.sendMessageOverSpaceBrew("buttonPress","boolean","true");
			// light.GetComponent<Renderer>().enabled = true;
			// yield return new WaitForSecondsRealtime(0.1f);

			// sbEvents.sendMessageOverSpaceBrew("buttonPress","boolean","false");
			// light.GetComponent<Renderer>().enabled = false;
			// yield return new WaitForSecondsRealtime(0.1f);

			// sbEvents.sendMessageOverSpaceBrew("buttonPress","boolean","true");
			// light.GetComponent<Renderer>().enabled = true;
			// yield return new WaitForSecondsRealtime(0.1f);

			// sbEvents.sendMessageOverSpaceBrew("buttonPress","boolean","false");
			// light.GetComponent<Renderer>().enabled = false;
			// yield return new WaitForSecondsRealtime(0.1f);

			
			//Send Spacebrew Command to turn on the light
			sbEvents.sendMessageOverSpaceBrew("buttonPress","boolean","true");
			yield return new WaitForSecondsRealtime(0.2f);
			light.GetComponent<Renderer>().enabled = true;
            System.Random r = new System.Random();
			float rand = r.Next(5,7);
			yield return new WaitForSecondsRealtime(rand);

			sbEvents.sendMessageOverSpaceBrew("buttonPress","boolean","false");
			yield return new WaitForSecondsRealtime(0.2f);
			light.GetComponent<Renderer>().enabled = false;
			float rand1 = r.Next(5,7);
			yield return new WaitForSecondsRealtime(rand1);
			// yield return null;
		}
		
    }

}

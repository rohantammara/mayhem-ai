using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
	
	void OnLevelWasLoaded ()
	{
		
		if(!FindObjectOfType<EventSystem>())
		{
			
			GameObject obj = new GameObject("EventSystem");

			
			obj.AddComponent<EventSystem>();
			obj.AddComponent<StandaloneInputModule>().forceModuleActive = true;
			obj.AddComponent<TouchInputModule>();
		}
	}
}

using UnityEngine;
using System.Collections;

public class QuitApplication : MonoBehaviour {

	public void Quit()
	{
		
	#if UNITY_STANDALONE
	
		Application.Quit();
	#endif

		
	#if UNITY_EDITOR
		
		UnityEditor.EditorApplication.isPlaying = false;
	#endif
	}
}

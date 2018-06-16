using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// in order to get this to show in inspector window
[System.Serializable]

// don't want this to be called in a script
public class Dialogue {

	// name of NPC
	public string name;
	// text area min lines = 3 , max lines = 10
	[TextArea(3, 10)]
	public string[] sentences;

}

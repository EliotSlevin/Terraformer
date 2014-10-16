using UnityEngine;
using System.Collections;

public class StartMenuOpenLevel : MonoBehaviour {


	

	void Update () {
		if (Input.anyKey) {
						Application.LoadLevel ("TerraformerMap");
				}
	}
}

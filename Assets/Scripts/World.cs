using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
	public GameObject blockBase;

	void CreateAWorld()
	{
		// floor
		for(int x=0; x<10; x++) {
			for(int z=0; z<4; z++) {
		 		GameObject go = (GameObject)Instantiate(blockBase);
				go.transform.parent = this.transform;
				go.transform.localPosition = new Vector3(x,0,z);
		 	}
		}
	}

	void Start () {
		CreateAWorld();
	}
	
	void Update () {
	
	}
}

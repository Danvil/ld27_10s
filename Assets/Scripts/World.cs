using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
	public GameObject blockBase;
	
	void AddBlock(float x, float y, float z)
	{
 		GameObject go = (GameObject)Instantiate(blockBase);
 		Block block = go.GetComponent<Block>();
 		block.basePosition = new Vector3(x,y,z);
		go.transform.parent = this.transform;
	}
	
	void CreateAWorld()
	{
		int W = 12;
		int D = 5;
		int H = 8;
		int WO = 5;
		// floor
		for(int x=0; x<W; x++) {
			for(int z=0; z<D; z++) {
				AddBlock(x, 0, z);
		 	}
		}
		// back wall
		for(int x=0; x<W; x++) {
			for(int h=0; h<H; h++) {
				AddBlock(x, h, D);
			}
		}
		// left wall
		for(int z=0; z<=D; z++) {
			for(int h=0; h<H; h++) {
				AddBlock(-1, h, z);
			}
		}
		// right wall
		for(int z=0; z<=D; z++) {
			for(int h=0; h<H; h++) {
				AddBlock(W, h, z);
			}
		}
		// front wall
		for(int x=-WO; x<=W+WO; x++) {
			for(int h=0; h<H; h++) {
				if(x < -1 || W < x)
					AddBlock(x, h, 0);
			}
		}
	}

	void Start () {
		CreateAWorld();
	}
	
	void Update () {
	
	}
}

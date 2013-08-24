using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Room : MonoBehaviour
{
	const float WOB = 0.03f;

	public GameObject blockBase;

	public List<Door> doors = new List<Door>();
	
	public Block AddBlock(int x, int y, int z)
	{
		if(doors.Any(
			door => (door.x <= x && x < door.x + door.wx)
				&& (door.y <= y && y < door.y + door.height)
				&& (door.z <= z && z < door.z + door.wz)
			) 
		) {
			return null;
		}
		GameObject go = (GameObject)Instantiate(blockBase);
		go.transform.parent = this.transform;
		go.transform.localPosition = new Vector3(x,y,z);
		Block block = go.GetComponent<Block>();
		block.SetYWobbleDirection();
		block.offset = new Vector3(
			WOB*(-1.0f + 2.0f*Random.value),
			WOB*(-1.0f + 2.0f*Random.value),
			WOB*(-1.0f + 2.0f*Random.value));
		return block;
	}

	public void AddDoor(Door door)
	{
		doors.Add(door);
	}
	
	public void Create(int W)
	{
		int D = 5;
		int H = 8;
		int WO = 5;
		// floor
		for(int x=0; x<W; x++) {
			for(int z=0; z<D; z++) {
				Block block = AddBlock(x, 0, z);
				block.SetRandomXZWobbleDirection();
				block.offset = new Vector3(
					WOB*(-1.0f + 2.0f*Random.value),
					0.0f,
					WOB*(-1.0f + 2.0f*Random.value));
		 	}
		}
		// back wall
		for(int x=0; x<W; x++) {
			for(int h=0; h<H; h++) {
				for(int z=D; z<=D+1; z++) {
					AddBlock(x, h, z);
				}
			}
		}
		// left wall
		for(int z=0; z<=D; z++) {
			for(int h=0; h<H; h++) {
				for(int x=-2; x<=-1; x++) {
					AddBlock(x, h, z);
				}
			}
		}
		// right wall
		for(int z=0; z<=D; z++) {
			for(int h=0; h<H; h++) {
				for(int x=W; x<=W+1; x++) {
					AddBlock(x, h, z);
				}
			}
		}
		// front wall
		for(int x=-WO; x<=W+WO; x++) {
			for(int h=0; h<H; h++) {
				if(x < -2 || W+1 < x)
					AddBlock(x, h, 0);
			}
		}
	}

	void Awake() {
		Globals.Room = this;
	}

	void Start () {
		// Door exit = new Door();
		// exit.x = 12;
		// exit.y = 1;
		// exit.z = 2;
		// exit.height = 2;
		// exit.wx = 2;
		// exit.wz = 2;
		// AddDoor(exit);
	}
	
	void Update () {	
	}
}

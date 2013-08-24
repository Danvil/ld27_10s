using UnityEngine;

public static class Tools
{
	public static Vector3 ChangeY(this Vector3 v, float y)
	{
		return new Vector3(v.x, y, v.z);
	}
}
			
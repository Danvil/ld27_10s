using UnityEngine;
using System.Collections;
using UnityEditor;

namespace EditorTools
{

	public class RoomGenerator : EditorWindow
	{
		[MenuItem("LD_27/Room Generator")]
		static void OpenWindow()
		{
			EditorWindow.GetWindow(typeof(RoomGenerator));
		}
		
		void OnGUI()
		{
			EditorGUIUtility.LookLikeInspector();
			if (GUILayout.Button("Generate"))
			{
				Execute();
			}
			// EditorGUILayout.LabelField("Parallel Rectangle RMSE: " + rmse);

		}
		
		void Execute()
		{
			Debug.Log("GO");
			Object pf = Resources.LoadAssetAtPath("Assets/Prefabs/Room.prefab", typeof(GameObject));
			GameObject go = (GameObject)Instantiate(pf);
			Room room = (Room)go.GetComponent<Room>();
			room.Create(12);
		}
		
	}

}
using UnityEngine;
using System.Collections;
using UnityEditor;

namespace EditorTools
{

	public class BlockTool : EditorWindow
	{
		[MenuItem("LD_27/Block Tool")]
		static void OpenWindow()
		{
			EditorWindow.GetWindow(typeof(BlockTool));
		}
		
		Mesh mesh;
		Material mat;
		
		void OnGUI()
		{
			EditorGUIUtility.LookLikeInspector();
			if (GUILayout.Button("Random Y Rotation"))
			{
				ExecuteRandomRotate();
			}
			if (GUILayout.Button("Set Mass to 1"))
			{
				ExecuteSetMass();
			}
			if (GUILayout.Button("Set Material"))
			{
				ExecuteSetMaterial();
			}
			mat = EditorGUILayout.ObjectField("Material", mat, typeof(Material)) as Material;
			if (GUILayout.Button("Set Mesh"))
			{
				ExecuteSetMesh();
			}
			mesh = EditorGUILayout.ObjectField("Mesh", mesh, typeof(Mesh)) as Mesh;
		}
		
		void ExecuteRandomRotate()
		{
			System.Random rnd = new  System.Random();
			object[] obj = GameObject.FindObjectsOfType(typeof(Block));
			foreach (object o in obj) {
				Block b = o as Block;
				if(b != null) {
					b.transform.rotation *= Quaternion.AngleAxis(rnd.Next(0,3)*90.0f, new Vector3(0,1,0));
				}
			}
		}

		void ExecuteSetMass()
		{
			System.Random rnd = new  System.Random();
			object[] obj = GameObject.FindObjectsOfType(typeof(Block));
			foreach (object o in obj) {
				Block b = o as Block;
				if(b != null) {
					b.rigidbody.mass = 1;
				}
			}
		}
		
		void ExecuteSetMaterial()
		{
			object[] obj = GameObject.FindObjectsOfType(typeof(Block));
			foreach (object o in obj) {
				Block b = o as Block;
				if(b != null) {
					b.renderer.material = mat;
				}
			}
		}
		
		void ExecuteSetMesh()
		{
			object[] obj = GameObject.FindObjectsOfType(typeof(Block));
			foreach (object o in obj) {
				Block b = o as Block;
				if(b != null) {
					b.GetComponent<MeshFilter>().mesh = mesh;
				}
			}
		}
		
	}

}
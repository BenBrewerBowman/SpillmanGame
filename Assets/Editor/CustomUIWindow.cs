using System;
using UnityEngine;
using UnityEditor;

public class CustomUIWindow : EditorWindow
{
	[MenuItem("Window/Custom UI")]
	static void Init()
	{
		CustomUIWindow window = EditorWindow.GetWindow<CustomUIWindow>();
		if (window != null)
		{
			window.titleContent.text = "Custom UI";
			window.Show();
		}
	}

	void OnGUI()
	{
		if (GUILayout.Button("Enable Keyword MIRROR_U"))
		{
			Shader.EnableKeyword("MIRROR_U");
		}
		if (GUILayout.Button("Disable Keyword MIRROR_U"))
		{
			Shader.DisableKeyword("MIRROR_U");
		}

		if (GUILayout.Button("Enable Keyword MIRROR_V"))
		{
			Shader.EnableKeyword("MIRROR_V");
		}
		if (GUILayout.Button("Disable Keyword MIRROR_V"))
		{
			Shader.DisableKeyword("MIRROR_V");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CharacterCreator : EditorWindow
{
	string characterName;

	float speed;

	float health;

	float basicAttackDamage;
	float basicAttackSpeed;
	float basicAttackRange;
	float basicAttackCooldown;

	Ability ability;

	Texture texture;

	[MenuItem("Window/Granny Wars/Character Creator")]
	[MenuItem("Window/Granny Wars/Character Creator %g")]
	public static void ShowWindow()
	{
		GetWindow(typeof(CharacterCreator));
	}



	void OnGUI()
	{
		
		GUILayout.Label("Granny wars", EditorStyles.boldLabel);
		characterName = EditorGUILayout.TextField("Character name", characterName);
		speed = EditorGUILayout.FloatField("Speed", speed);

		health = EditorGUILayout.FloatField("Health", health);

		GUILayout.Label("Basic attack");
		basicAttackDamage = EditorGUILayout.FloatField("Basic Attack DMG", basicAttackDamage);
		basicAttackSpeed = EditorGUILayout.FloatField("Basic Attack", basicAttackSpeed);
		basicAttackRange = EditorGUILayout.FloatField("Speed", basicAttackRange);
		basicAttackCooldown = EditorGUILayout.FloatField("Speed", basicAttackCooldown);

		ability = (Ability)EditorGUILayout.ObjectField("Ability", ability, typeof(Ability), false);

		if (GUILayout.Button("Generate Character"))
		{
			//Setting up actual character
			PlayerStats stats = (PlayerStats)CreateInstance(typeof(PlayerStats));
			stats.name = characterName;
			stats.speed = speed;
			stats.health = health;
			stats.basicAttackDamage = basicAttackDamage;
			stats.basicAttackSpeed = basicAttackSpeed;
			stats.basicAttackRange = basicAttackRange;
			stats.basicAttackCooldown = basicAttackCooldown;
			stats.ability = ability;

			GameObject newCharacter = new GameObject();
			GameObject meshHolder = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			meshHolder.transform.SetParent(newCharacter.transform);
			meshHolder.name = "replace with mesh";

			newCharacter.AddComponent<C_Player>();


			//Creating folder
			if (!Directory.Exists("Assets/Prefabs/Generated_Characters"))
			{
				AssetDatabase.CreateFolder("Assets/Prefabs", "Generated_Characters");

			}
			if (!Directory.Exists("Assets/Prefabs/Generated_Characters/DataStats"))
			{
				AssetDatabase.CreateFolder("Assets/Prefabs/Generated_Characters", "DataStats");
			}

			//Setting stats
			newCharacter.GetComponent<C_Player>().stats = stats;

			//Saving prefab
			string dataPath = "Assets/Prefabs/Generated_Characters/DataStats/" + characterName;
			if (File.Exists(dataPath + "_Datapack.asset"))
				dataPath += System.DateTime.Now.ToString("yy'_'MM'_'dd_HH'_'mm'_'ss") + "_Datapack.asset";
			else
				dataPath += "_Datapack.asset";
			AssetDatabase.CreateAsset(stats, dataPath);


			string prefabPath = "Assets/Prefabs/Generated_Characters/" + characterName;
			if (File.Exists(prefabPath + ".prefab"))
				prefabPath += "_" + System.DateTime.Now.ToString("yy'_'MM'_'dd_HH'_'mm'_'ss") + ".prefab";
			else
				prefabPath += ".prefab";

			PrefabUtility.SaveAsPrefabAsset(newCharacter, prefabPath);
			DestroyImmediate(newCharacter);
		}
	}
}

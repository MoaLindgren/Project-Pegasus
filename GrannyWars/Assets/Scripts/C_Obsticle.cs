using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class C_Obsticle : MonoBehaviour
{
	public C_ObsticlePoint[] obsticlePoints;
	[SerializeField] private Mesh mesh;
	[SerializeField] private int numberOfPoints = 8;
	[SerializeField] private float distanceFromMesh = 1;
	[SerializeField] private bool maximumNumberOfPoints;
	[SerializeField] GameObject obsticlePoint;
	private List<Vector3> chosenVertices;

	public void Spawn()
	{
		chosenVertices = new List<Vector3>(1024);

		//Finds vertices where y = 0
		foreach (Vector3 vertex in mesh.vertices)
		{

			if (vertex.y < 0.01 && vertex.y > -0.01)
			{
				chosenVertices.Add(vertex);
			}
		}

		print(chosenVertices.Count + " eligable vertices added");

		//Calculates which vertices that should be used.
		if (numberOfPoints <= chosenVertices.Count)
		{
			chosenVertices = SortVertecies(chosenVertices);
			obsticlePoints = new C_ObsticlePoint[chosenVertices.Count];
			int _iterations = maximumNumberOfPoints ? chosenVertices.Count : numberOfPoints;
			GameObject _obsticlePoints = new GameObject();
			_obsticlePoints.name = "Obsticle Points";
			_obsticlePoints.transform.parent = transform;
			_obsticlePoints.transform.SetSiblingIndex(0);
			for (int i = 0; i < _iterations; i++)
			{
				int _index = maximumNumberOfPoints ? 1 : chosenVertices.Count / numberOfPoints;
				Vector3 _vertex = chosenVertices[_index * i];
				GameObject _obj = Instantiate(obsticlePoint);
				_obj.transform.position = gameObject.transform.position + Vector3.Scale(_vertex, transform.localScale) + _vertex * distanceFromMesh;
				_obj.transform.position = _obj.transform.position - _obj.transform.position.y * Vector3.up;
				_obj.transform.name = "ObsticlePoint " + (i + 1);
				_obj.transform.parent = _obsticlePoints.transform;
				_obj.transform.SetSiblingIndex(i);
				obsticlePoints[i] = _obj.GetComponent<C_ObsticlePoint>();
			}
		}
		else
		{
			Debug.LogError("<color=red>You cant add more obsticlepoints than there are vertices! </color>", gameObject);
		}

		List<Vector3> SortVertecies(List<Vector3> vertices)
		{
			List<Vector3> sorted = new List<Vector3>(vertices.Count);
			sorted.Add(vertices[0]);
			for (int i = 1; i < vertices.Count; i++)
			{
				for (int j = 0; j < sorted.Count; j++)
				{
					if (vertices[i].z <= sorted[j].z)
					{
						sorted.Insert(j, vertices[i]);
						break;
					}
					if (j == sorted.Count - 1)
					{
						sorted.Add(vertices[i]);
					}
				}
			}
			for (int i = sorted.Count - 1; i > 0; i--)
			{
				if (sorted[i].x < 0)
				{
					Vector3 _temp = sorted[i];
					sorted.RemoveAt(i);
					sorted.Add(_temp);
				}
			}

			return sorted;
		}
	}
}

[CustomEditor(typeof(C_Obsticle))]
public class C_ObsticleEditor : Editor
{
	override public void OnInspectorGUI()
	{
		DrawDefaultInspector();
		C_Obsticle obsticle = (C_Obsticle)target;
		if (GUILayout.Button("Instantiate obsticle points"))
		{
			obsticle.Spawn();
		}
	}

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextEmitter : MonoBehaviour
{

	public GameObject Prefab;

	public void EmitText(string text, Color color, float scale = 1)
	{
		FloatingText textObject = GameObject.Instantiate(Prefab, transform.position, Quaternion.identity)
			.GetComponent<FloatingText>();
		textObject.Setup(text, color, scale);
	}
}

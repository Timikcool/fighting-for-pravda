using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{

	public TextMesh TextMesh;
	public float TravelSpeed;
	public float TravelDistance;

	public void Setup(string text, Color color, float scale = 1f)
	{
		TextMesh.text = text;
		TextMesh.color = color;
		transform.localScale = Vector3.one * scale;
	}
	
	void Update () {
		transform.Translate(Vector3.up*TravelSpeed*Time.deltaTime);
		if (transform.position.y > TravelDistance)
		{
			GameObject.Destroy(gameObject);
		}
	}
}

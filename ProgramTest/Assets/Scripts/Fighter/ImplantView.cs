using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplantView : MonoBehaviour
{
	public GameObject[] ViewPrefabs;

	public void Setup(int viewId)
	{
		GameObject.Instantiate(ViewPrefabs[viewId], transform);
	}
}

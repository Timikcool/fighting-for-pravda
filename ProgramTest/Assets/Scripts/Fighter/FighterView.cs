using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterView : MonoBehaviour
{
	public enum FighterBodyPart
	{
		Head,
		Torso,
		Hips,
		UparmL,
		UparmR,
		DwarmL,
		DwarmR,
		HandL,
		HandR,
		UplegL,
		UplegR,
		DwlegL,
		DwlegR,
		FootL,
		FootR
	}
	
	public struct FighterImplant
	{
		public int ViewId;
		public FighterBodyPart BodyPart;
		public int X;
		public int Y;
		public int Rotation;
	}

	public GameObject ImplantPrefab;
	
	public GameObject Head;
	public GameObject Torso;
	public GameObject Hips;
	public GameObject UparmL;
	public GameObject UparmR;
	public GameObject DwarmL;
	public GameObject DwarmR;
	public GameObject HandL;
	public GameObject HandR;
	public GameObject UplegL;
	public GameObject UplegR;
	public GameObject DwlegL;
	public GameObject DwlegR;
	public GameObject FootL;
	public GameObject FootR;
	
	public void Setup(List<FighterImplant> implants)
	{
		foreach (var implant in implants)
		{
			CreateImplant(implant);
		}
	}

	private void CreateImplant(FighterImplant implant)
	{
		FighterBodyPartView bodyPart = GetBodyPart(implant.BodyPart).GetComponent<FighterBodyPartView>();
		ImplantView implantView = GameObject.Instantiate(ImplantPrefab, bodyPart.transform).GetComponent<ImplantView>();
		
		implantView.Setup(implant.ViewId);
		implantView.transform.localPosition = new Vector3(
			bodyPart.LeftX + (bodyPart.RightX - bodyPart.LeftX)*(float)implant.X/100f,
			bodyPart.TopY + (bodyPart.BotY - bodyPart.TopY)*(float)implant.Y/100f);
		implantView.transform.Rotate(Vector3.back, implant.Rotation);
	}

	private GameObject GetBodyPart(FighterBodyPart bodyPart)
	{
		switch (bodyPart)
		{
				case FighterBodyPart.Head:
					return Head;
				case FighterBodyPart.Torso:
					return Torso;
				case FighterBodyPart.Hips:
					return Hips;
				case FighterBodyPart.UparmL:
					return UparmL;
				case FighterBodyPart.UparmR:
					return UparmR;
				case FighterBodyPart.DwarmL:
					return DwarmL;
				case FighterBodyPart.DwarmR:
					return DwarmR;
				case FighterBodyPart.HandL:
					return HandL;
				case FighterBodyPart.HandR:
					return HandR;
				case FighterBodyPart.UplegL:
					return UplegL;
				case FighterBodyPart.UplegR:
					return UplegR;
				case FighterBodyPart.DwlegL:
					return DwlegL;
				case FighterBodyPart.DwlegR:
					return DwlegR;
				case FighterBodyPart.FootL:
					return FootL;
				case FighterBodyPart.FootR:
					return FootR;	
				default:
					return null;
		}
	}

	void OnGUI()
	{
		if (UnityEngine.GUI.Button(new Rect(10, 10, 150, 100), "Add Implants"))
		{
			CreateImplant(new FighterImplant()
			{
				BodyPart = FighterBodyPart.Head,
				ViewId = 0,
				X = 50,
				Y = 50,
				Rotation = 45
			});
		}
	}
}

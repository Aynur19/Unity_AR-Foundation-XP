using UnityEngine;

public class DragonAR : InteractableObjectAR, IAnimatable
{
	[SerializeField]
	private float width;

	[SerializeField]
	private Animator anim;
	public bool DragonIsAnimated;

	[SerializeField]
	private bool animIsFly;

	[SerializeField]
	private bool animIsIdel;

	[SerializeField]
	private bool animIsRun;

	[SerializeField]
	private bool animIsWalk;


	private void ValidAnimationChange(string name, bool value)
	{
		if(nameof(animIsFly) == name && animIsFly == value) 
		{
			animIsIdel = animIsRun = animIsWalk = false;
		}
		else if(nameof(animIsIdel) == name && animIsIdel == value)
		{
			animIsFly = animIsRun = animIsWalk = false;
		}
		else if(nameof(animIsRun) == name && animIsRun == value)
		{
			animIsFly = animIsIdel = animIsWalk = false;
		}
		else if(nameof(animIsWalk) == name && animIsWalk == value)
		{
			animIsFly = animIsIdel = animIsRun = false;
		}
	}

	public void Animate()
	{
		DragonIsAnimated = true;
		anim.SetBool(nameof(DragonIsAnimated), DragonIsAnimated);
	}

	public void Fly()
	{
		ValidAnimationChange(nameof(animIsFly), true);
	}

	public void Idel()
	{
		ValidAnimationChange(nameof(animIsIdel), true);
	}

	public void Run()
	{
		ValidAnimationChange(nameof(animIsRun), true);
	}

	public void Walk()
	{
		ValidAnimationChange(nameof(animIsWalk), true);
	}

	public override void HighlightingObject(float outlineWidth)
	{
		base.HighlightingObject(outlineWidth);

		Debug.Log($"DragonAR is Highlighted? {IsHighlited}");

		var skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
		if(skinnedMesh != null && skinnedMesh.materials != null)
		{
			if(!IsHighlited)
			{
				Debug.Log($"DragonAR materials count = ? {skinnedMesh.materials.Length}");
				if(skinnedMesh.materials.Length > 1)
				{
					for(int i = 0; i < skinnedMesh.materials.Length; i++)
					{
						if(skinnedMesh.materials[i] != null)
						{
							skinnedMesh.materials[i].SetFloat(GameEnvConstants.OutlineWidthName, outlineWidth);
						}
					}
				}
				else if(skinnedMesh.materials.Length == 1)
				{
					skinnedMesh.material.SetFloat(GameEnvConstants.OutlineWidthName, outlineWidth);

				}
				
				if(skinnedMesh.materials.Length != 0)
				{
					IsHighlited = true;
				}
			}
			else
			{
				if(skinnedMesh.materials.Length > 1)
				{
					for(int i = 0; i < skinnedMesh.materials.Length; i++)
					{
						if(skinnedMesh.materials[i] != null)
						{
							skinnedMesh.materials[i].SetFloat(GameEnvConstants.OutlineWidthName, 0f);
						}
					}
				}
				else if(skinnedMesh.materials.Length == 1)
				{
					skinnedMesh.material.SetFloat(GameEnvConstants.OutlineWidthName, 0f);

				}
				
				if(skinnedMesh.materials.Length != 0)
				{
					IsHighlited = false;
				}
			}
		}
	}
}

using UnityEngine;

public class InteractableObjectAR : ObjectAR, IHighlightable
{
	public bool CanCreated { get; set; } = true;

	// IHighlightable
	public bool IsHighlited { get; set; }

	public virtual void HighlightingObject()
	{
		var mesh = GetComponent<MeshRenderer>();

		if(mesh != null && mesh.material != null)
		{
			if(mesh.material.GetFloat(GameEnvConstants.OutlineWidthName) < GameEnvConstants.OutlineWidthMiddle)
			{
				mesh.material.SetFloat(GameEnvConstants.OutlineWidthName, GameEnvConstants.OutlineWidthMax);
				IsHighlited = true;
			}
			else
			{
				mesh.material.SetFloat(GameEnvConstants.OutlineWidthName, 0f);
				IsHighlited = false;
			}
		}
		else
		{
			var skinnedMesh = GetComponent<SkinnedMeshRenderer>();
			if(skinnedMesh != null && skinnedMesh.material != null)
			{
				if(skinnedMesh.material.GetFloat(GameEnvConstants.OutlineWidthName) < GameEnvConstants.OutlineWidthMiddle)
				{
					skinnedMesh.material.SetFloat(GameEnvConstants.OutlineWidthName, GameEnvConstants.OutlineWidthMax);
					IsHighlited = true;
				}
				else
				{
					skinnedMesh.material.SetFloat(GameEnvConstants.OutlineWidthName, 0f);
					IsHighlited = false;
				}
			}
		}

	}

	public void TryDestroy()
	{
		Destroy(gameObject);
	}
}

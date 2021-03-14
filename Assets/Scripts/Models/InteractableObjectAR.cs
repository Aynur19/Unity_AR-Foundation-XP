using UnityEngine;

public class InteractableObjectAR : ObjectAR, IHighlightable
{
	public bool CanCreated { get; set; } = true;

	// IHighlightable
	public bool IsHighlited { get; set; }

	public virtual void HighlightingObject(float outlineWidth)
	{
		var mesh = GetComponent<MeshRenderer>();

		if(mesh != null && mesh.material != null)
		{
			if(!IsHighlited)
			{
				mesh.material.SetFloat(GameEnvConstants.OutlineWidthName, outlineWidth);
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
				if(IsHighlited)
				{
					skinnedMesh.material.SetFloat(GameEnvConstants.OutlineWidthName, outlineWidth);
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

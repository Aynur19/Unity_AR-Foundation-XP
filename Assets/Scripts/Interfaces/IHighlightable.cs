using UnityEngine;

public interface IHighlightable
{
	bool IsHighlited { get; set; }

	void HighlightingObject(float outlineWidth);
}

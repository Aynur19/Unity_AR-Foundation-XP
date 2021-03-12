using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHighlightable
{
	bool IsHighlited { get; set; }

	void HighlightingObject();
}

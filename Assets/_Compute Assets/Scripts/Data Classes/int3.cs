using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct int3
{
	public int3(int x, int y, int z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public int x;
	public int y;
	public int z;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct VecMatPair
{
	public Vector3 point;
	public Matrix4x4 matrix;

	public const int BYTES = 76;
}
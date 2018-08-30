using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct FractalControlData
{
	public double cx, cy;       // center of the view rect
	public double depthFactor;  // how deep we are, zoom factor
	public double borderChange; // speed in which the zoom changes
	public double k;
}

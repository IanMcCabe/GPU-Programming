using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaRectCompute : BufferCompute<double, FractalControlData>
{
	public AreaRectCompute(string kernalProperty)
		: base(kernalProperty)
	{
	}

	protected override void _InitData()
	{
		// here we define the initial bottom left and top right borders of the fractal space
		Data = new double[4];
		Data[0] = -2.0f;
		Data[1] = -2.0f;
		Data[2] = 2.0f;
		Data[3] = 2.0f;
	}

	protected override void _InitStride()
	{
		Stride = sizeof(double);
	}

	protected override void _UpdateData(FractalControlData info)
	{
		Data[0] = info.cx - info.depthFactor * info.borderChange;
		Data[1] = info.cy - info.depthFactor * info.borderChange;
		Data[2] = info.cx + info.depthFactor * info.borderChange;
		Data[3] = info.cy + info.depthFactor * info.borderChange;
	}
}

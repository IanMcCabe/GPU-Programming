using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsCompute : BufferCompute<Color, Color>
{
	public ColorsCompute(string kernalProperty)
		: base(kernalProperty)
	{
	}

	protected override void _InitData()
	{
		// here we create a color palette to visualize fractal (each pixel will be colored depending on how many iterations required to move a point outside the R = 2 circle)
		Data = new Color[256];
		int i = 0;
		while (i < Data.Length)
		{
			Data[i] = new Color(0, 0, 0, 1);
			if (i >= 0 && i < 128)
				Data[i] += new Color(0, 0, Mathf.PingPong(i * 4, 256) / 256, 1);
			if (i >= 64 && i < 192)
				Data[i] += new Color(0, Mathf.PingPong((i - 64) * 4, 256) / 256, 0, 1);
			if (i >= 128 && i < 256)
				Data[i] += new Color(Mathf.PingPong(i * 4, 256) / 256, 0, 0, 1);
			i++;
		}
	}

	protected override void _InitStride()
	{
		Stride = 4 * 4;
	}

	protected override void _UpdateData(Color color)
	{
	}
}

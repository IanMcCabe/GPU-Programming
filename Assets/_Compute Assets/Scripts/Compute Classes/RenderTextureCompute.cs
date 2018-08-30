using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RenderTextureCompute : ComputeBase<RenderTexture>
{
	[Header("Texture Settings")]
	public int3 textureDimensions = new int3(256, 256, 24);

	public RenderTextureCompute(string kernalProperty, int3 textureDimensions)
		: base(kernalProperty)
	{
		this.textureDimensions = textureDimensions;
	}

	public override void Initialize(ComputeShader shader, int kernelIndex)
	{
		base.Initialize(shader, kernelIndex);
		InitTexture();
		CreateTexture();

		shader.SetTexture(kernelIndex, kernalProperty, result);
	}

	public virtual void InitTexture()
	{
		result = new RenderTexture(textureDimensions.x, textureDimensions.y, textureDimensions.z);		
	}

	protected virtual void CreateTexture()
	{
		result.enableRandomWrite = true;                 // this is requred to work as compute shader side written texture
														 //outputTexture.memorylessMode = RenderTextureMemoryless.None;
														 //outputTexture.
		result.Create();                                 // yes, we need to run Create() to actually create the texture
		result.filterMode = FilterMode.Point;
	}
}

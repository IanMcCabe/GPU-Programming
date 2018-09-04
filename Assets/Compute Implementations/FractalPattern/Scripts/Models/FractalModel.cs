using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalModel : ModelBase, IModel<FractalControlData>
{
	public AreaRectCompute areaRectCompute;
	public ColorsCompute colorsCompute;
	public RenderTextureCompute textureCompute;

	ComputeGroupBase computeGroupBase;

	private void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
		// Initializes buffers
		areaRectCompute = new AreaRectCompute("rect");
		colorsCompute = new ColorsCompute("colors");
		textureCompute = new RenderTextureCompute("textureOut", new int3(1024, 1024, 32));

		// Initializes Shader.
		ComputeShader shader = Resources.Load<ComputeShader>("csFractal");
		computeGroupBase = new ComputeGroupBase(shader, "pixelCalc", new int3(32, 32, 1),
			new List<ComputeBase> { areaRectCompute, colorsCompute, textureCompute });

		UpdateViewEvent.Invoke(textureCompute.result);
	}

	public void UpdateData(FractalControlData data)
	{
		areaRectCompute.UpdateData(data);
		computeGroupBase.Dispatch();
	}
	
	private void OnDestroy()
	{
		computeGroupBase.Destory();
	}
}

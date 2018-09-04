using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHairModel : ModelBase, IModel<hairNodeData>, IModel<circleColliderData>
{
	public HairNodeComute hairNodeCompute;
	public circleColliderCompute circleColliderCompute;
	public RenderTextureCompute textureCompute;

	ComputeGroupBase computeGroupBase;

	void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
		// Initialize Buffers
		hairNodeCompute = new HairNodeComute("hairNodesBuffer");
		circleColliderCompute = new circleColliderCompute("circleCollidersBuffer");
		
		textureCompute = new RenderTextureCompute("textureOut", new int3(1024, 1024, 32));

		// Initialize Shaders
		ComputeShader shader = Resources.Load<ComputeShader>("shader");
		computeGroupBase = new ComputeGroupBase(shader, "pixelCalc", new int3(32, 32, 1),
			new List<ComputeBase> { hairNodeCompute, circleColliderCompute, textureCompute });
	}

	public void UpdateData(hairNodeData data)
	{
		throw new System.NotImplementedException();
	}

	public void UpdateData(circleColliderData data)
	{
		throw new System.NotImplementedException();
	}
	
	private void OnDestroy()
	{
	}
}


public class HairNodeComute : BufferCompute<hairNodeData, hairNodeData>
{
	public hairNodeData[] hairNodesArray;
	static public int nHairs;
	static public float nodeStepSize;
	static public int nodesPerHair;

	public HairNodeComute(string kernalProperty) : base(kernalProperty)
	{
		nHairs = 200;
		nodesPerHair = 50;
		nodeStepSize = 5;
	}

	protected override void _InitData()
	{
		int hairIndex;
		int nodeIndex;

		Data = new hairNodeData[nHairs * nodesPerHair];
		for(int i = 0; i < Data.Length; i++)
		{
			hairIndex = i / nodesPerHair;
			nodeIndex = i % nodesPerHair;
			hairNodesArray[i].x = hairIndex - nHairs / 2;
			hairNodesArray[i].y = -nodeStepSize * (nodeIndex - nodesPerHair / 2);
			hairNodesArray[i].vx = 0;
			hairNodesArray[i].vy = 0;
			hairNodesArray[i].dvx = 0;
			hairNodesArray[i].dvy = 0;
			i++;
		}
	}

	protected override void _InitStride()
	{
		Stride = 4 * 8;
	}

	protected override void _UpdateData(hairNodeData data)
	{
		throw new System.NotImplementedException();
	}
}

public class circleColliderCompute : BufferCompute<int, int>
{
	public circleColliderCompute(string kernalProperty) : base(kernalProperty)
	{
	}

	protected override void _InitData()
	{
		throw new System.NotImplementedException();
	}

	protected override void _InitStride()
	{
		throw new System.NotImplementedException();
	}

	protected override void _UpdateData(int data)
	{
		throw new System.NotImplementedException();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeGroupBase
{
	public ComputeShader shader;
	public string kernalName;
	public int kernalIndex;
	public int3 threadGroup;

	protected List<ComputeBase> computeBases;

	/// <summary>
	/// Creates the object, but doesn't auto-initalize since there are no computebase objects attached yet.
	/// </summary>
	/// <param name="shader"></param>
	/// <param name="kernalName"></param>
	/// <param name="threadGroup"></param>
	public ComputeGroupBase(ComputeShader shader, string kernalName, int3 threadGroup)
	{
		this.shader = shader;
		this.kernalName = kernalName;
		this.threadGroup = threadGroup;
	}

	/// <summary>
	/// Auto-initalizes the new object with the computebases list since its provided.
	/// </summary>
	/// <param name="shader"></param>
	/// <param name="kernalName"></param>
	/// <param name="threadGroup"></param>
	/// <param name="computeBases"></param>
	public ComputeGroupBase(ComputeShader shader, string kernalName, int3 threadGroup, List<ComputeBase> computeBases) : this(shader, kernalName, threadGroup)
	{
		this.computeBases = computeBases;
		Initialize();
	}

	private void Initialize()
	{
		if (shader == null) { Debug.LogError("Shader is null"); }
		if (!shader.HasKernel(kernalName)) { Debug.LogError("No Kernel in this shader", shader); }
		kernalIndex = shader.FindKernel(kernalName);
		
		foreach (ComputeBase computeBase in computeBases)
		{
			computeBase.Initialize(shader, kernalIndex);
		}
	}

	public void Dispatch()
	{
		shader.Dispatch(kernalIndex, threadGroup.x, threadGroup.y, threadGroup.z);
	}

	/// <summary>
	/// Adds a computerbase to the end of the list
	/// </summary>
	/// <param name="computebase"></param>
	public void AddComputeBase(ComputeBase computebase)
	{
		computeBases.Add(computebase);
	}

	public void Destory()
	{
		foreach (ComputeBase computeBase in computeBases)
		{
			computeBase.Destroy();
		}
	}
}

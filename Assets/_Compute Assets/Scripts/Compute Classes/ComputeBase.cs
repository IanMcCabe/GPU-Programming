using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ComputeBase<T> : ComputeBase
{
	[Header("Base Settings")]
	public T result;
	
	public string kernalProperty;

	public ComputeBase(string kernalProperty)
	{
		this.kernalProperty = kernalProperty;
	}
}

public abstract class ComputeBase
{
	public virtual void Initialize(ComputeShader shader, int kernelIndex)
	{
	}

	public virtual void Destroy()
	{
	}
}

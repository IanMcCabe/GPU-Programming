using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class BufferCompute<T, D> : ComputeBase<ComputeBuffer> where D : struct
{
	//[Header("Buffer Settings")]
	public T[] Data;
	protected int Stride;

	public BufferCompute(string kernalProperty)
		: base(kernalProperty)
	{
	}
	
	public override void Initialize(ComputeShader shader, int kernelIndex)
	{
		base.Initialize(shader, kernelIndex);

		InitStride();
		InitData();
		ApplyData();

		shader.SetBuffer(kernelIndex, kernalProperty, result);
	}

	protected abstract void _InitStride();
	public void InitStride()
	{
		_InitStride();
	}

	protected abstract void _InitData();
	public void InitData()
	{
		_InitData();
		result = new ComputeBuffer(Data.Length, Stride);
	}

	protected virtual void ApplyData()
	{
		result.SetData(Data);
	}
	
	protected abstract void _UpdateData(D data);
	public void UpdateData(D data)
	{
		_UpdateData(data);
		ApplyData();
	}

	public override void Destroy()
	{
		result.Dispose();
		base.Destroy();
	}	
}

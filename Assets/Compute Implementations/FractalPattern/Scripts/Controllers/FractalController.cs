using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class FractalController : MonoBehaviour, IController
{
	[Serializable]
	public class UnityFracDataEvent : UnityEvent<FractalControlData> { };
	public UnityFracDataEvent updateModelEvent;

	protected FractalControlData data;
	protected bool move;                            // is middle mouse button down?
	protected bool inputChange;                     // if any input affected zoom or view position, we need to recalculate and redraw the texture
	

	private void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
		data.k = 0.0009765625f;
		data.borderChange = 2.0;
		data.depthFactor = 1.0;
		data.cx = 0;
		data.cy = 0;
		move = false;
		inputChange = true;
	}

	private void Update()
	{
		ManipulateControls();
	}

	public void ManipulateControls()
	{
		if (Input.mouseScrollDelta.y != 0)
		{
			data.depthFactor -= 0.2 * data.depthFactor * Input.mouseScrollDelta.y;
			inputChange = true;
		}

		if (Input.GetMouseButtonDown(2))
		{
			move = true;
		}

		if (Input.GetMouseButtonUp(2))
		{
			move = false;
		}

		if (move)
		{
			data.cx -= 100 * data.k * data.depthFactor * Input.GetAxis("Mouse X");
			data.cy -= 100 * data.k * data.depthFactor * Input.GetAxis("Mouse Y");
		}

		if (move && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
		{
			inputChange = true;
		}

		UpdateModel();
	}

	public void UpdateModel()
	{
		if (inputChange)
		{
			updateModelEvent.Invoke(data);
			inputChange = false;
		}
	}
}

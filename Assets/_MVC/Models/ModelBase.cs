using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class ModelBase : MonoBehaviour
{
	[Serializable]
	public class UnityTextureEvent : UnityEvent<Texture> { };
	public UnityTextureEvent UpdateViewEvent;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class View_2D : MonoBehaviour, IView<Texture>
{
	protected GameObject mainCanvas;
	protected UnityEngine.UI.Image outputImage;

	private void Awake()
	{
		initialize();
	}

	public void initialize()
	{
		mainCanvas = GameObject.Find("Canvas");
		mainCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
		mainCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
		mainCanvas.GetComponent<UnityEngine.UI.CanvasScaler>().uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
		mainCanvas.GetComponent<UnityEngine.UI.CanvasScaler>().referenceResolution = new Vector2(1024, 1024);

		if (Screen.width > Screen.height)
		{
			mainCanvas.GetComponent<UnityEngine.UI.CanvasScaler>().matchWidthOrHeight = 0.0f;
		}
		else
		{
			mainCanvas.GetComponent<UnityEngine.UI.CanvasScaler>().matchWidthOrHeight = 1.0f;
		}

		outputImage = GameObject.Find("Canvas/Image").GetComponent<UnityEngine.UI.Image>();
		outputImage.color = new Color(1, 1, 1, 1);
		outputImage.type = UnityEngine.UI.Image.Type.Simple;
		outputImage.GetComponent<RectTransform>().sizeDelta = new Vector2(1024, 1024);
	}

	public void UpdateView(Texture view)
	{
		outputImage.material.mainTexture = view;
	}
}

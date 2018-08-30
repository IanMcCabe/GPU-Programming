using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModel<D>
{
	void Initialize();
	void UpdateData(D data);
}

public interface IView<V>
{
	void initialize();
	void UpdateView(V view);
}

public interface IController
{
	void Initialize();
	void ManipulateControls();
	void UpdateModel();
}

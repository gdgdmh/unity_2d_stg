using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StgGameObjectObserver {

	public abstract void Update();

	public void SetObject(StgGameObjectSubject stgGameObjectSubject) {
		subject = stgGameObjectSubject;
	}

	protected StgGameObjectSubject subject;
}

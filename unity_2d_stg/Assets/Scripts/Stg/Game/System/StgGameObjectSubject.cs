using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgGameObjectSubject {

	public StgGameObjectSubject() {
	}

	public void Update() {
		foreach (StgGameObjectObserver observer in observers) {
			observer.Update();
		}
	}

	public void AddObserver(StgGameObjectObserver observer) {
		observers.Add(observer);
		observer.SetObject(this);
	}

	List<StgGameObjectObserver> observers = new List<StgGameObjectObserver>();
}

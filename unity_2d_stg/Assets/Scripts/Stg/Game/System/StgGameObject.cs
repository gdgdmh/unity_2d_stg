using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgGameObject {

	public StgGameObject() {
	}

	public void Initialize() {
	}

    // Update is called once per frame
    public void Update() {
    }

	public bool IsActive() {
		return isActive;
	}

	public bool IsAlive() {
		return isAlive;
	}

	//protected 
	protected bool isActive; // そのオブジェクトが活動しているか(生きているかは無関係)
	protected bool isAlive; // そのオブジェクトが生きているか
}

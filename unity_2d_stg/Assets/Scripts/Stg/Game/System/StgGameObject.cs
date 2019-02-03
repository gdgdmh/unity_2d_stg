﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgGameObject : MonoBehaviour {

	public StgGameObject() {
	}

	public virtual void Initialize() {
		health = new ObjectHealth();

		health.Initialize();
		health.SetMaxHealth(1);
		health.SetHealth(1);
	}

	public virtual void Start() {
	}

    // Update is called once per frame
    public virtual void Update() {
    }

	//public bool IsActive() {
	//	return isActive;
	//}

	public bool IsAlive() {
		return health.IsAlive();
	}

	protected ObjectHealth health; // 生命力
	//protected bool isActive; // そのオブジェクトが活動しているか(生きているかは無関係)
}

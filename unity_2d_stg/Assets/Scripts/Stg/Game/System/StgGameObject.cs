using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgGameObject {

	public StgGameObject() {
	}

	public void Initialize() {
		health = new ObjectHealth();

		health.Initialize();
		health.SetMaxHealth(1);
		health.SetHealth(1);
	}

    // Update is called once per frame
    public void Update() {
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

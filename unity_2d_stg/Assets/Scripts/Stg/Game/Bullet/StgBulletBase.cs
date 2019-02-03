using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgBulletBase : MonoBehaviour, IStgAttack {

	public StgBulletBase() {
	}

    // Start is called before the first frame update
    public void Start() {
    }

    // Update is called once per frame
    public void Update() {
    }

	/// <summary>
	/// 攻撃(IStgAttackのオーバーライド)
	/// </summary>
	/// <param name="stgGameObject"></param>
	public void Attack(StgGameObject stgGameObject) {
	}
}

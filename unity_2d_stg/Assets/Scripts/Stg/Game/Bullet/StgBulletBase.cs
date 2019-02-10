using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgBulletBase : StgGameObject, IStgAttack {

	public StgBulletBase() {
	}

    // Start is called before the first frame update
    public override void Start() {
    }

    // Update is called once per frame
    public override void Update() {
    }

	/// <summary>
	/// 攻撃(IStgAttackのオーバーライド)
	/// </summary>
	/// <param name="stgGameObject"></param>
	public virtual void Attack(StgGameObject stgGameObject) {
	}
}

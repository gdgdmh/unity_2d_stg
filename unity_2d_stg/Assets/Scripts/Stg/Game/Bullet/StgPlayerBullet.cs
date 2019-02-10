using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerBullet : StgBulletBase {

	public StgPlayerBullet() {
	}

    // Start is called before the first frame update
    public override void Start() {
    }

    // Update is called once per frame
    public override void Update() {
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		MhCommon.Assert(rigidbody2D != null, "NormalEnemy::Update transform null");
		// 移動
		rigidbody2D.velocity = new Vector2(0.0f, 15.0f);
    }

	/// <summary>
	/// 攻撃(IStgAttackのオーバーライド)
	/// </summary>
	/// <param name="stgGameObject"></param>
	public override void Attack(StgGameObject stgGameObject) {

	}


}

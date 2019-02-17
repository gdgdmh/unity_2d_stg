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

		// エリアオーバー処理
		ProcessAreaOver(rigidbody2D);
    }

	/// <summary>
	/// エリアオーバー処理
	/// </summary>
	/// <param name="rigidbody2D"></param>
	protected void ProcessAreaOver(Rigidbody2D rigidbody2D) {
		if (IsAreaOver(rigidbody2D)) {
			Destroy(this.gameObject);
		}
	}

	/// <summary>
	/// エリアオーバーしているか
	/// </summary>
	/// <param name="rigidbody2D"></param>
	/// <returns></returns>
	protected bool IsAreaOver(Rigidbody2D rigidbody2D) {
		float x = rigidbody2D.position.x;
		float y = rigidbody2D.position.y;

		if ((x > 10.0f) || (x < -10.0f) || (y > 10.0f) || (y < -10.0f)) {
			return true;
			//Destroy(this.gameObject);
		}
		return false;
	}

	/// <summary>
	/// 攻撃(IStgAttackのオーバーライド)
	/// </summary>
	/// <param name="stgGameObject"></param>
	public override void Attack(StgGameObject stgGameObject) {

	}


}

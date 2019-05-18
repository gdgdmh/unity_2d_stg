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
		if (CheckAreaOver()) {
			ProcessAreaOver();
		}
    }

	public override bool CheckAreaOver() {
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		MhCommon.Assert(rigidbody2D != null, "NormalEnemy::CheckAreaOver transform null");

		float x = rigidbody2D.position.x;
		float y = rigidbody2D.position.y;
		if ((x > 10.0f) || (x < -10.0f) || (y > 10.0f) || (y < -10.0f)) {
			return true;
		}
		return false;
	}

	public override void ProcessAreaOver() {
		Destroy(this.gameObject);
	}

	/// <summary>
	/// 攻撃(IStgAttackのオーバーライド)
	/// </summary>
	/// <param name="stgGameObject"></param>
	public override void Attack(StgGameObject stgGameObject) {
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		//MhCommon.Print("StgPlayerBullet::OnTriggerEnter2D tag=" + collision.tag);
		if (collision.tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kEnemy)) {
			// 敵と当たったら消滅する
			Destroy(this.gameObject);
		}

	}

}

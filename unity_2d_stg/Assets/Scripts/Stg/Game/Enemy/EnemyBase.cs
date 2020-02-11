using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : StgGameObject, IAddableScore, IStgItemDroppable {

	public EnemyBase() {
	}

	public void Awake() {
		ttt = -1;
	}

	public override void Initialize() {
		base.Initialize();
	}

    // Update is called once per frame
    public override void Update() {
    }

	/// <summary>
	/// 当たり判定
	/// </summary>
	/// <param name="collision">対象</param>
	protected virtual void OnTriggerEnter2D(Collider2D collision) {
		if (IsHit(collision.tag)) {
			// ヒットエフェクト
			Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
			MhCommon.Assert(rigidbody2D != null, "EnemyBase::OnTriggerEnter2D() rigidbody2D null");
			/*
			// アイテムドロップ
			itemDropper.SetOffset(new Vector3(rigidbody2D.position.x, rigidbody2D.position.y, 0));
			itemDropper.Print();
			Drop();
			*/
		}
	}

	/// <summary>
	/// スコアの加算
	/// </summary>
	public void AdditionalScore(int score) {
		SceneShare.Instance.GetGameTemporaryData().GetScoreData().AdditionalScore(score);
	}

	public void SetItemDropper(StgItemMultiDropper dropper) {
		itemDropper.Copy(dropper);
		ttt = 1;
	}

	public int GetCount() {
		return itemDropper.GetCount();
	}

	/// <summary>
	/// アイテムドロップ
	/// </summary>
	public IEnumerable<GameObject> Drop() {
		if (GetCount() > 0) {
			return itemDropper.Drop();
		}
		return null;
	}

	/// <summary>
	/// 当たったか(プレイヤーかプレイヤーの弾なら当たったとみなす)
	/// </summary>
	/// <returns>trueなら当たっている</returns>
	protected bool IsHit(string tag) {
		if ((tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kPlayerBullet))
			|| (tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kPlayer))) {
			return true;
		}
		return false;
	}

	protected StgItemMultiDropper itemDropper = new StgItemMultiDropper(); // アイテムドロップ
	protected int ttt = 0;
}

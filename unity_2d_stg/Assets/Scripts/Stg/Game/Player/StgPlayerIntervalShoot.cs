using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの弾を発射する(インターバル設定)
/// 発射位置はshotPositionとoffsetの足しあわせによって確定
/// </summary>
public class StgPlayerIntervalShoot {
	public StgPlayerIntervalShoot() {
	}

	/// <summary>
	/// 初期化
	/// </summary>
	public void Initialize() {
		shootInterval = 1.0f;
		currentShootInterval = shootInterval;
		shootPosition = new Vector3(0.0f, 0.0f, 0.0f);
		offset = new Vector3(0.0f, 0.0f, 0.0f);
	}

	/// <summary>
	/// 更新処理
	/// </summary>
	/// <param name="elapsedTime">前回からの経過時間</param>
	/// <param name="touchAction">タッチ情報</param>
	/// <param name="dragAction">ドラッグ情報</param>
	public void Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		// 一定時間ごとに攻撃
		currentShootInterval -= elapsedTime;
		if (currentShootInterval <= 0.0f) {
			// 攻撃処理
			ExecuteShoot();
			// 攻撃再間隔設定
			ResetInterval();
		}
	}

	/// <summary>
	/// 発射間隔のリセット
	/// </summary>
	public void ResetInterval() {
		currentShootInterval = shootInterval;
	}

	/// <summary>
	/// 発射間隔の設定
	/// </summary>
	/// <param name="interval">発射間隔</param>
	public void SetInterval(float interval) {
		shootInterval = interval;
	}

	/// <summary>
	/// 発射位置の設定
	/// </summary>
	/// <param name="position">発射位置</param>
	public void SetShootPosition(Vector3 position) {
		shootPosition = position;
	}

	/// <summary>
	/// 発射位置オフセットの設定
	/// </summary>
	/// <param name="offset">発射位置のオフセット</param>
	public void SetShootOffset(Vector3 offset) {
		this.offset = offset;
	}

	/// <summary>
	/// 発射処理
	/// </summary>
	protected virtual void ExecuteShoot() {
		// PlayerBulletを動的生成
		StgPlayerBulletFactory factory = new StgPlayerBulletFactory();
		GameObject bullet = factory.Create(StgBulletConstant.Type.kPlayerNormal);

		// 発射位置の設定 + オフセット設定
		Vector3 position = CalcShootPosition();

		Object.Instantiate(bullet, position, Quaternion.identity);
	}

	/// <summary>
	/// 発射位置を計算する
	/// </summary>
	/// <returns>発射位置(位置とオフセットを加味した位置)</returns>
	protected Vector3 CalcShootPosition() {
		// 発射位置の設定 + オフセット設定
		Vector3 position = shootPosition;
		position += offset;
		return position;
	}

	private float shootInterval = 1.0f;
	private float currentShootInterval = 1.0f; // 現在の攻撃再間隔時間
	protected Vector3 shootPosition; // 発射位置
	protected Vector3 offset; // オフセット
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerIntervalShot {
	public StgPlayerIntervalShot() {
	}

	public void Initialize() {
		shotInterval = 1.0f;
		shotPosition = new Vector3(0.0f, 0.0f, 0.0f);
		offset = new Vector3(0.0f, 0.0f, 0.0f);
	}

	public void Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		// 一定時間ごとに攻撃
		shotInterval -= elapsedTime;
		if (shotInterval <= 0.0f) {
			// 攻撃処理
			AttackProcess();
			// 攻撃再間隔設定
			ResetInterval();
		}
	}

	public void ResetInterval() {
		currentShotInterval = shotInterval;
	}

	public void SetInterval(float interval) {
		shotInterval = interval;
	}


	public void SetShotPosition(Vector3 position) {
		shotPosition = position;
	}

	public void SetShotOffset(Vector3 offset) {
		this.offset = offset;
	}

	private void AttackProcess() {
		// PlayerBulletを動的生成
		StgPlayerBulletFactory factory = new StgPlayerBulletFactory();
		GameObject bullet = factory.Create(StgBulletConstant.Type.kPlayerNormal);

		// 発射位置の設定 + オフセット設定
		Vector3 position = shotPosition;
		position += offset;

		Object.Instantiate(bullet, position, Quaternion.identity);
	}

	private float shotInterval = 1.0f;
	private float currentShotInterval = 1.0f; // 現在の攻撃再間隔時間
	private Vector3 shotPosition; // 発射位置
	private Vector3 offset; // オフセット
}

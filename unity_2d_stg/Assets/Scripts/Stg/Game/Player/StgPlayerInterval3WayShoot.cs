using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerInterval3WayShoot : StgPlayerIntervalShoot {
	public StgPlayerInterval3WayShoot() {

	}

	protected override void ExecuteShoot() {
		// PlayerBulletを動的生成
		StgPlayerBulletFactory factory = new StgPlayerBulletFactory();

		// 発射位置の設定 + オフセット設定
		Vector3 position = CalcShootPosition();
		shootPositions[0] = position;
		shootPositions[1] = position;
		shootPositions[2] = position;
		shootPositions[0].x += kAttackPositionXOffset;
		shootPositions[1].x += 0;
		shootPositions[2].x += -kAttackPositionXOffset;

		GameObject[] bullets = new GameObject[kShootNum];
		bullets[0] = factory.Create(StgBulletConstant.Type.kPlayerNormal);
		bullets[1] = factory.Create(StgBulletConstant.Type.kPlayerNormal);
		bullets[2] = factory.Create(StgBulletConstant.Type.kPlayerNormal);

		for (int i = 0; i < kShootNum; ++i) {
			Object.Instantiate(bullets[i], shootPositions[i], Quaternion.identity);
		}
	}
	private static readonly int kShootNum = 3;
	private static readonly float kAttackPositionXOffset = 0.7f; // 攻撃の位置オフセットX
	protected Vector3[] shootPositions = new Vector3[kShootNum];
}

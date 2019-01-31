using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth {

	public ObjectHealth() {
	}

	/// <summary>
	/// 生命力の設定
	/// </summary>
	/// <param name="health"></param>
	public void SetHealth(int health) {
		this.health = health;
	}

	/// <summary>
	/// 生命力の増加
	/// </summary>
	/// <param name="health"></param>
	public void Add(int health) {
	}

	/// <summary>
	/// 生命力の減少
	/// </summary>
	/// <param name="health"></param>
	public void Sub(int health) {
	}

	/// <summary>
	/// 生命力の取得
	/// </summary>
	/// <returns></returns>
	public int GetHealth() {
		return health;
	}

	/// <summary>
	/// 生死フラグの取得
	/// </summary>
	/// <returns></returns>
	public bool IsAlive() {
		return isAlive;
	}

	/// <summary>
	/// 生命力が変動したときの処理
	/// </summary>
	/// <param name="beforeHealth">変動前の生命力</param>
	/// <param name="afterHealth">変動後の生命力</param>
	protected void ChangeHealthProc(int beforeHealth, int afterHealth) {
	}

	/// <summary>
	/// 生死フラグの判定
	/// </summary>
	/// <param name="health"></param>
	/// <returns></returns>
	protected bool CheckAlive(int health) {
		// 0以下になったら死亡とする
		if (health <= 0) {
			return false;
		}
		return true;
	}

	protected int health; // 生命力
	protected bool isAlive; // 生死フラグ(trueなら生存状態 falseなら死亡状態)
}

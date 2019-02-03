using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth {

    public enum EventType : int {
		kSetter,		// setterメソッドにより発生したイベント
		kAdd,			// addメソッドにより発生したイベント
		kSub,			// subメソッドにより発生したイベント
    };

	public ObjectHealth() {
		Initialize();
	}

	// パラメータの初期化
	public void Initialize() {
		health = 0;
		maxHealth = 0;
		isAlive = false;
	}

	/// <summary>
	/// 生命力の設定
	/// </summary>
	/// <param name="health"></param>
	public void SetHealth(int health) {
		int beforeHealth = this.health;
		ChangeHealthBeforeProc(EventType.kSetter, beforeHealth);
		this.health = health;
		ChangeHealthAfterProc(EventType.kSetter, beforeHealth, this.health);
	}

	/// <summary>
	/// 生命力の最大値の設定
	/// </summary>
	/// <param name="maxHealth"></param>
	public void SetMaxHealth(int maxHealth) {
		this.maxHealth = maxHealth;

		// healthがmaxより高くなってしまったらまるめるためにイベントが発生する
		if (maxHealth < health) {
			int beforeHealth = this.health;
			ChangeHealthBeforeProc(EventType.kSetter, beforeHealth);
			ChangeHealthAfterProc(EventType.kSetter, beforeHealth, maxHealth);
		}
	}

	/// <summary>
	/// 生命力の増加
	/// </summary>
	/// <param name="health"></param>
	public void Add(int health) {
		int beforeHealth = this.health;
		ChangeHealthBeforeProc(EventType.kAdd, beforeHealth);
		this.health += health;
		ChangeHealthAfterProc(EventType.kAdd, beforeHealth, this.health);
	}

	/// <summary>
	/// 生命力の減少
	/// </summary>
	/// <param name="health"></param>
	public void Sub(int health) {
		int beforeHealth = this.health;
		ChangeHealthBeforeProc(EventType.kSub, beforeHealth);
		this.health += health;
		ChangeHealthAfterProc(EventType.kSub, beforeHealth, this.health);
	}

	/// <summary>
	/// 生命力最大値の取得
	/// </summary>
	/// <returns></returns>
	public int GetMaxHealth() {
		return maxHealth;
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
	/// 生命力の変動が行われる直前のイベント
	/// </summary>
	/// <param name="beforeHealth"></param>
	protected void ChangeHealthBeforeProc(EventType eventType, int beforeHealth) {
	}

	/// <summary>
	/// 生命力が変動した後のイベント
	/// </summary>
	/// <param name="beforeHealth">変動前の生命力</param>
	/// <param name="afterHealth">変動後の生命力</param>
	protected void ChangeHealthAfterProc(EventType eventType, int beforeHealth, int afterHealth) {
		// 最大Healthのまるめ処理
		if (afterHealth > maxHealth) {
			health = maxHealth;
		}
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
	protected int maxHealth; // 生命力の最大値
	protected bool isAlive; // 生死フラグ(trueなら生存状態 falseなら死亡状態)
}

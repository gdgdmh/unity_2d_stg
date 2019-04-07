using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// int管理用のクラス(将来的に暗号化を施す可能性あり)
/// 値の最大値や最小値を設定し管理することが目的
/// </summary>
public class ManagedInteger {

	/// <summary>
	/// コンストラクタ(値は0 最大値、最小値は型の最大、最小値が設定)
	/// </summary>
	public ManagedInteger() {
		value = 0;
		maxValue = System.Int32.MaxValue;
		minValue = System.Int32.MinValue;
	}

	/// <summary>
	/// 値の設定
	/// </summary>
	/// <param name="value">設定される値</param>
	public void Set(int value) {
		this.value = value;
		Adjust();
	}

	/// <summary>
	/// 値の最大値の設定
	/// </summary>
	/// <param name="max">設定される値の最大値</param>
	public void SetMaxValue(int max) {
		maxValue = max;
		MhCommon.Assert(maxValue >= minValue, "ManagedInteger::SetMaxValue() maxValue >= minValue");
		Adjust();
	}

	/// <summary>
	/// 値の最小値の設定
	/// </summary>
	/// <param name="min">設定される値の最小値</param>
	public void SetMinValue(int min) {
		minValue = min;
		MhCommon.Assert(minValue <= maxValue, "ManagedInteger::SetMinValue() minValue <= maxValue");
		Adjust();
	}

	/// <summary>
	/// 各値の設定(値、最大値、最小値)
	/// </summary>
	/// <param name="value">設定される値</param>
	/// <param name="max">設定される値の最大値</param>
	/// <param name="min">設定される値の最小値</param>
	public void SetValues(int value, int max, int min) {
		this.value = value;
		maxValue = max;
		minValue = min;
		MhCommon.Assert(maxValue >= minValue, "ManagedInteger::SetValues() maxValue >= minValue");
		MhCommon.Assert(minValue <= maxValue, "ManagedInteger::SetValues() minValue <= maxValue");
		Adjust();
	}

	/// <summary>
	/// 値の加算
	/// </summary>
	/// <param name="value">加算する値</param>
	public void Add(int value) {
		this.value += value;
		Adjust();
	}

	/// <summary>
	/// 値の減算
	/// </summary>
	/// <param name="value">減算する値</param>
	public void Sub(int value) {
		this.value -= value;
		Adjust();
	}

	/// <summary>
	/// 値の取得
	/// </summary>
	/// <returns></returns>
	public int Get() {
		return value;
	}

	/// <summary>
	/// 値の最大値の取得
	/// </summary>
	/// <returns></returns>
	public int GetMaxValue() {
		return maxValue;
	}

	/// <summary>
	/// 値の最小値の取得
	/// </summary>
	/// <returns></returns>
	public int GetMinValue() {
		return minValue;
	}

	/// <summary>
	/// 値を最小値と最大値の間に収まるように設定する
	/// </summary>
	protected void Adjust() {
		if (value < minValue) {
			value = minValue;
		}
		if (value > maxValue) {
			value = maxValue;
		}
	}

	private int value;		// 値
	private int minValue;	// 値の最大値
	private int maxValue;	// 値の最小値
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StgItemConstant {
	public enum Type {
		kPowerup,
		kScoreup,
		kUnknown
	};

	public static readonly string kStringItemPowerup = "powerup";
	public static readonly string kStringItemScoreup = "scoreup";
	public static readonly string kUnknown = "";

	public static Type GetStringToType(string itemType) {
		if (itemType == kStringItemPowerup) {
			return Type.kPowerup;
		} else if (itemType == kStringItemScoreup) {
			return Type.kScoreup;
		}
		return Type.kUnknown;
	}

	public static readonly int kScorePowerup = 100;
	public static readonly int kScoreScoreup = 500;
}

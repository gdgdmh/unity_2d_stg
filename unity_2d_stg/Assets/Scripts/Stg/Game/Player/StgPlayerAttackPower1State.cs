using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackPower1State : StgPlayerAttackState {
	public StgPlayerAttackPower1State() {
	}

	public override void Initialize() {
		base.Initialize();
		Debug.Log("StgPlayerAttackPower1State::Initialize");
	}

	public override void OnStateActive(state beforeState) {
		base.OnStateActive(beforeState);
		Debug.Log("StgPlayerAttackPower1State::OnStateActive");
	}

	public override void OnStateNonActive(state nextState) {
		base.OnStateNonActive(nextState);
		Debug.Log("StgPlayerAttackPower1State::Update");
	}

	public override state Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		base.Update(elapsedTime, touchAction, dragAction);
		Debug.Log("StgPlayerAttackPower1State::Update");
		return state.Power1;
	}
}

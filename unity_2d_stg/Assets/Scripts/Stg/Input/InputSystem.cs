using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem {

    public InputSystem() {
        unitySingleTouchAction = new UnitySingleTouchAction();
    }

    public void Initialize() {
        unitySingleTouchAction.Initialize();
    }

    public UnitySingleTouchAction GetSingleTouchAction() {
        return unitySingleTouchAction;
    }

    private UnitySingleTouchAction unitySingleTouchAction;
}

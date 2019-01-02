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

    public void SetDisplaySize(int width, int height) {
        unitySingleTouchAction.SetDisplaySize(width, height);
    }

    public UnitySingleTouchAction GetSingleTouchAction() {
        return unitySingleTouchAction;
    }

    private UnitySingleTouchAction unitySingleTouchAction;
}

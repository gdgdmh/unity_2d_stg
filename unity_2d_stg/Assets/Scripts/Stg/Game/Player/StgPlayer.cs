using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayer : MonoBehaviour {

    StgPlayer() {

    }

    private void Awake() {
        // 動的にスクリプトを追加
        if (stgPlayerController == null) {
            stgPlayerController = this.gameObject.AddComponent<StgPlayerController>() as StgPlayerController;
            MhCommon.Assert(stgPlayerController != null, "StgPlayer::Awake() StgPlayerController AddComponent failure");
        }

        // 試しにcall
        stgPlayerController.Update();
        //MhCommon.Print("update");
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        UnitySingleTouchAction touchAction = SceneShare.Instance.GetInput().GetSingleTouchAction();
        touchAction.Update();
        if (touchAction.IsTouchBegan()) {
            float x = 0.0f;
            float y = -0.2f;
            float speed = 1.0f;
            Vector2 direction = new Vector2(x, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
            //Transform transform = GetComponent<Transform>();
            //transform

        }
    }

    private IStgPlayerController stgPlayerController;
    private I2dFloatPositionable position;
}

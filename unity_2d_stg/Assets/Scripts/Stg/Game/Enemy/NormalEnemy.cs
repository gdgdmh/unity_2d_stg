using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : EnemyBase
{
	public NormalEnemy() {
	}

	public override void Initialize() {
	}

	// Start is called before the first frame update
	public override void Start() {
    }

    // Update is called once per frame
    public override void Update() {
		//Transform transform = GetComponent<Transform>();
		//MhCommon.Assert(transform != null, "NormalEnemy::Update transform null");
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		MhCommon.Assert(rigidbody2D != null, "NormalEnemy::Update transform null");

		rigidbody2D.angularVelocity = 30.0f;

    }
}

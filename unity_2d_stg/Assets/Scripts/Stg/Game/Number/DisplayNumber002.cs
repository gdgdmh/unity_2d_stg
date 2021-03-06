﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Number002の表示制御を行う
/// 子にスプライトレンダラーが設定されていることが前提
/// </summary>
public class DisplayNumber002 : MonoBehaviour {

	public DisplayNumber002() {
		isStartFirstTime = true;
		number = 0;
	}

	private void Awake() {
		numSprites = new Sprite[kNumSpriteNum];
		for (int i = 0; i < kNumSpriteNum; ++i) {
			numSprites[i] = Resources.Load<Sprite>("Textures/num002/num002_" + string.Format("{0:00}", i));
			//numSprites[i] = Resources.Load<Sprite>("Textures/num002/num002_00");
			MhCommon.Assert(numSprites[i] != null, "DisplayNumber002::Start() Resource.Load Sprite failure");
		}
		//sprite = Resources.Load<Sprite>("Textures/num002/num002_00");


		// 子に設定されているSpriteRendererを取得する
		numSpriteRenderers = new SpriteRenderer[kDisplaySpriteNum];
		SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
		for (int i = 1; i <= kDisplaySpriteNum; ++i) {
			string targetSpriteName = string.Format(kDefaultGameObjectFormat, i);
			foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
				string spriteName = spriteRenderer.name;
				// 名前に対応したスプライトを取得
				if (targetSpriteName == spriteName) {
					numSpriteRenderers[i - 1] = spriteRenderer;
					//MhCommon.Print("Get=" + i);
					break;
				}
			}
			MhCommon.Assert(numSpriteRenderers[i - 1] != null, "DisplayNumber002::Start() SpriteRenderer not set=" + i);
		}

		// SpriteRendererに設定されているtransformを取得する
		numTransforms = new Transform[kDisplaySpriteNum];
		for (int i = 0; i < kDisplaySpriteNum; ++i) {
			numTransforms[i] = numSpriteRenderers[i].transform;
		}

		basePosition.x = 0.0f;//2.0f;
		basePosition.y = 0.0f;
		basePosition.z = 0.0f;
		offset.x = 0;//-0.32f;
		offset.y = 0;
		offset.z = 0;

		// SpriteRendererの位置を設定
		ApplyPosition();

		Set(0);

	}

	public void Start() {
	}

	/// <summary>
	/// 数値の表示設定
	/// </summary>
	/// <param name="num"></param>
	public void Set(int num) {
		int[] setNums = GetNumArray(num);
		int count = 0;
		foreach (SpriteRenderer spriteRenderer in numSpriteRenderers) {
			spriteRenderer.sprite = numSprites[setNums[count]];
			++count;
		}
		number = num;
	}

	public int Get() {
		return number;
	}

	/// <summary>
	/// 基準位置を設定(1桁目を基準とする)
	/// </summary>
	/// <param name="position"></param>
	public void SetBasePosition(Vector3 position) {
		basePosition = position;
	}

	/// <summary>
	/// SpriteRendererのScaleを設定する
	/// </summary>
	public void SetScale(Vector3 scale) {
		for (int i = 0; i < kDisplaySpriteNum; ++i) {
			numTransforms[i].localScale = scale;
			//numTransforms[i] = numSpriteRenderers[i].transform;
		}
	}

	/// <summary>
	/// 数字間のオフセットを指定
	/// </summary>
	/// <param name="offset">オフセット</param>
	public void SetOffset(Vector3 offset) {
		this.offset = offset;
	}

	/// <summary>
	/// 基準位置やオフセットを適用する
	/// </summary>
	public void ApplyPosition() {
		Vector3 position = basePosition;
		foreach (SpriteRenderer spriteRenderer in numSpriteRenderers) {
			spriteRenderer.transform.position = position;
			position.x += offset.x;
			position.y += offset.y;
			position.z += offset.z;
			//MhCommon.Print(spriteRenderer.transform.position.x);
		}
	}

	/// <summary>
	/// 各桁が格納された配列を取得する
	/// 123ならint[] = (1,2,3)となる
	/// </summary>
	/// <param name="num">配列に格納するもととなる数値</param>
	/// <returns>各桁の数値が格納されたint配列</returns>
	protected int[] GetNumArray(int num) {
		int[] result = new int[kDisplaySpriteNum];
		MhCommon.Assert(result != null, "DisplayNumber002::GetNumArray array null");
		int displayNum = num;
		// 初期化
		for (int i = 0; i < kDisplaySpriteNum; ++i) {
			result[i] = 0;
		}
		// 負の値なら反転
		if (displayNum < 0) {
			displayNum *= -1;
		}
		// MinValueのときは反転できないのでMaxValueとする
		if (displayNum == System.Int32.MinValue) {
			displayNum = System.Int32.MaxValue;
		}

		// 配列に各桁の数値を設定
		int count = 0;
		while (displayNum > 0) {
			int digit = displayNum % 10;
			displayNum = displayNum / 10;
			result[count] = digit;
			++count;
		}
		return result;
	}

	static readonly string kDefaultGameObjectFormat = "Num{0:00}";
	static readonly int kNumSpriteNum = 10;
	static readonly int kDisplaySpriteNum = 10;
	protected SpriteRenderer[] numSpriteRenderers;	// 各桁のSpriteRenderer
	protected Sprite[] numSprites;					// 数字のスプライトオブジェクト
	protected Transform[] numTransforms;			// 各桁のtransform

	protected Vector3 basePosition; // 基準位置(1桁目の位置)
	protected Vector3 offset;		// 1桁ごとにずらすオフセット
	protected int number;
	protected bool isStartFirstTime; // Start()を初回だけ実行する
	//protected Vector3 

	// 画像を持っている(0～9)
	// 

	//GameObject.Find("ScoreImage").GetComponent<Image>().sprite= numimage[number[0]];
	// とりあえず画像を表示してみる

	////private GameObject go;
	//private Sprite sprite;
	////public Sprite sprite2;
	//private new SpriteRenderer renderer;
	////private new SpriteRenderer renderer2;
	//bool firstTime = true;

}

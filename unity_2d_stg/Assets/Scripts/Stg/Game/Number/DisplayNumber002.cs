using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Number002の表示制御を行う
/// 子にスプライトレンダラーが設定されていることが前提
/// </summary>
public class DisplayNumber002 : MonoBehaviour {

	public DisplayNumber002() {
	}

	public void Start() {

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

		basePosition.x = 0.0f;//2.0f;
		basePosition.y = 0.0f;
		basePosition.z = 0.0f;
		offset.x = 0;//-0.32f;
		offset.y = 0;
		offset.z = 0;

		// SpriteRendererの位置を設定
		ApplyPosition();

		Set(0);
		/*
		{
			Vector3 position = basePosition;
			foreach (SpriteRenderer spriteRenderer in numSpriteRenderers) {
				spriteRenderer.sprite = numSprites[dummyNums[count]];
				++count;
			}
		}
		*/
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

	}

	/// <summary>
	/// 基準位置を設定(1桁目を基準とする)
	/// </summary>
	/// <param name="position"></param>
	public void SetBasePosition(Vector3 position) {
		basePosition = position;
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
	/// </summary>
	/// <param name="num"></param>
	/// <returns></returns>
	protected int[] GetNumArray(int num) {
		int[] result = new int[kDisplaySpriteNum];
		MhCommon.Assert(result != null, "DisplayNumber002::GetNumArray array null");
		// 初期化
		for (int i = 0; i < kDisplaySpriteNum; ++i) {
			result[i] = 0;
		}
		// 負の値なら反転
		if (num < 0) {
			num *= -1;
		}
		// 配列に各桁の数値を設定
		int count = 0;
		while (num > 0) {
			int digit = num % 10;
			num = num / 10;
			result[count] = digit;
			++count;
		}
		return result;
	}

	static readonly string kDefaultGameObjectFormat = "Num{0:00}";
	static readonly int kNumSpriteNum = 10;
	static readonly int kDisplaySpriteNum = 10;
	protected SpriteRenderer[] numSpriteRenderers;
	protected Sprite[] numSprites;

	protected Vector3 basePosition; // 基準位置(1桁目の位置)
	protected Vector3 offset;		// 1桁ごとにずらすオフセット
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

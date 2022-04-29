using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartsControler : MonoBehaviour
{

	//　現在どのパーツの並び替えをしているか
	private int nowParts;
	//　完成したかどうか
	private bool completed = false;
	//　パーツのリスト
	[SerializeField]　private List<GameObject> PartsList;
	public bool nowControllTarget;  //現在操作中のターゲットかどうか
	[SerializeField] private Vector3 CorrectCoordinate; //正解の座標。すべてのパーツの座標と合致で図形が完成

	void Start()
	{

	}

	void Update()
	{
		if (nowControllTarget)
		{
			//　Qキーが押されたら操作パーツを次のパーツに変更する
			if (Input.GetKeyDown("q"))
			{
				ChangeParts(nowParts);
			}

			bool compleatfrag = true;
			Vector3 vec = PartsList[0].transform.position;
			for (int i=0; i<PartsList.Count; i++)
            {
				if (vec != PartsList[i].transform.position) compleatfrag = false;
            }
			Debug.Log("dd");
			if(compleatfrag) completed = true;
			if (completed) TargetCleared();
		}
	}

	//　操作パーツ変更メソッド
	void ChangeParts(int tempNowParts)
	{
		//　現在操作しているパーツを移動できなくする
		PartsList[tempNowParts].GetComponent<ControlOnOffParts>().ChangeControl(false);
		//　次のパーツの番号を設定
		var nextParts = tempNowParts + 1;
		if (nextParts >= PartsList.Count)
		{
			nextParts = 0;
		}
		//　次のキャラクターを動かせるようにする
		PartsList[nextParts].GetComponent<ControlOnOffParts>().ChangeControl(true);
		//　現在のキャラクター番号を保持する
		nowParts = nextParts;
	}

	//Undoして一つ前のパーツに操作を渡す
	public void UndoParts()
    {
		//　現在操作しているパーツを移動できなくする
		PartsList[nowParts].GetComponent<ControlOnOffParts>().ChangeControl(false);
		//　次のパーツの番号を設定
		var nextParts = nowParts - 1;
		if (nextParts < 0)
		{
			nextParts = 0;
			Debug.Log("一番はじめのパーツです。Undoできません。");
		}
		//　次のキャラクターを動かせるようにする
		PartsList[nextParts].GetComponent<ControlOnOffParts>().ChangeControl(true);
		//　現在のキャラクター番号を保持する
		nowParts = nextParts;
	}

	//ターゲット操作可能にするメソッド
	public void StartControll()
    {
		Debug.Log("StartControll()が起動");
		this.gameObject.SetActive(true);
		nowControllTarget = true;
		//　最初の操作パーツを0番目のターゲットにする
		nowParts = 0;
		PartsList[0].GetComponent<ControlOnOffParts>().ChangeControl(true);
	}
	//TargetControllerから操作を終了することを受け取るメソッド
	public void EndControll()
	{
		Debug.Log("EndControll()が起動");
		nowControllTarget = false;
		PartsList[nowParts].GetComponent<ControlOnOffParts>().ChangeControl(false);
		this.gameObject.SetActive(false);
	}

	//ターゲットがクリアしたときの処理諸々を行う
	public void TargetCleared()
	{
		Debug.Log("TargetCleared()が起動");
		//アクティブターゲットの変更
		GameObject.Find("TargetControll").GetComponent<TargetController>().ChangeTarget();

		//得点の処理

		//クリアの演出

	}

}


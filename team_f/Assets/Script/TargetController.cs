using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetController : MonoBehaviour
{

	//　現在どのターゲットの並び替えをしているか
	private int nowTarget;
	//　ターゲットのリスト
	[SerializeField] private List<GameObject> TargetList;
	GameObject passbottun;

	void Start()
	{
		//　最初の操作ターゲットを0番目のターゲットにする
		nowTarget = 0;
		TargetList[0].GetComponent<PartsControler>().StartControll();

		passbottun = GameObject.Find("PassButton");
	}

	void Update()
	{

	}

	//　操作ターゲット変更メソッド
	public void ChangeTarget()
	{
		Debug.Log("ChangeTarget()が起動");
		//　現在操作しているターゲットを移動できなくする
		TargetList[nowTarget].GetComponent<PartsControler>().EndControll();
		//　次のターゲットの番号を設定
		var nextTarget = nowTarget + 1;
		if (nextTarget >= TargetList.Count)
		{
			nextTarget = 0;
		}
		//　次のターゲットに移動権を与える
		TargetList[nextTarget].GetComponent<PartsControler>().StartControll();
		//　現在のキャラクター番号を保持する
		nowTarget = nextTarget;
	}
	// 現在のターゲットにUndo司令を出すメソッド
	public void ReqestUndo()
    {
		Debug.Log("ReqestUndo()が起動");
		TargetList[nowTarget].GetComponent<PartsControler>().UndoParts();
	}

	// 現在のターゲットにパーツチェンジ司令を出す
	public void ReqestChangeParts()
	{
		Debug.Log("ReqestChangeParts()が起動");
		TargetList[nowTarget].GetComponent<PartsControler>().ChangeParts();
	}
}


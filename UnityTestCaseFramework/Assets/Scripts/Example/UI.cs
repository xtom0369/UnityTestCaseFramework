using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTestCaseFramework;

/// <summary>
/// 
/// </summary>
/// <author>xtom</author>
public class UI : MonoBehaviour
{
	void Start()
	{
		var useItemBtn = GameObject.Find("Canvas/UseItemBtn").GetComponent<Button>();
		useItemBtn.onClick.AddListener(OnViewUseItemBtnClick);
	}

	void OnViewUseItemBtnClick()
	{
		Log.Debug("使用道具");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏介绍界面 Game Rule of Line up (Game introduction page)
/// </summary>
public class IntroductionPage : BasePage
{
    public Button mBtnSkip;
    private void Start()
    {
        mBtnSkip.onClick.RemoveAllListeners();
        mBtnSkip.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.OpenPage(EPageType.LineUpPage);
        }));
    }
}

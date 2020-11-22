using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏介绍界面 Game rule of restuarants (Game introduction page)
/// </summary>
public class IntroductionPage5 : BasePage
{
    public Button mBtnSkip;
    private void Start()
    {
        mBtnSkip.onClick.RemoveAllListeners();
        mBtnSkip.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.OpenPage(EPageType.ResaurantsPage);
        }));
    }
}

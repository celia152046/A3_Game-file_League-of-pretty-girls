using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 开始界面 Title starting page
/// </summary>
public class StartPage : BasePage
{
    public Button mBtnMusicOff, mBtnMusicOn, mBtnHelp, mBtnStart;

    public GameObject mHelpRoot;
    public Button mBtnClose;
    void Start()
    {        
        mBtnMusicOff.onClick.RemoveAllListeners();
        mBtnMusicOff.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mBtnMusicOff.gameObject.SetActive(false);
            mBtnMusicOn.gameObject.SetActive(true);
            AudioManager.Instance.SetMusicTurn(false);
        }));
        mBtnMusicOn.onClick.RemoveAllListeners();
        mBtnMusicOn.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mBtnMusicOff.gameObject.SetActive(true);
            mBtnMusicOn.gameObject.SetActive(false);
            AudioManager.Instance.SetMusicTurn(true);
        }));
        mBtnHelp.onClick.RemoveAllListeners();
        mBtnHelp.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mHelpRoot.SetActive(true);
        }));
        mBtnStart.onClick.RemoveAllListeners();
        mBtnStart.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.OpenPage(EPageType.IntroductionPage);
        }));

        mBtnClose.onClick.RemoveAllListeners();
        mBtnClose.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mHelpRoot.SetActive(false);
        }));
    }
    private void OnEnable()
    {
        #region 检测初始音乐开关状态 
        //check the orignial status of music control button
        if (AudioManager.Instance.IsOn())
        {
            mBtnMusicOff.gameObject.SetActive(true);
            mBtnMusicOn.gameObject.SetActive(false);

            AudioManager.Instance.PlayMusic1();
        }
        else
        {
            mBtnMusicOff.gameObject.SetActive(false);
            mBtnMusicOn.gameObject.SetActive(true);

            AudioManager.Instance.StopMusic();
        }
        #endregion
    }
}

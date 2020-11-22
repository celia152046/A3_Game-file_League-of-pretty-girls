using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public enum EPageType
{
    StartPage,
    IntroductionPage,
    LineUpPage,
    AchievementPage,
    IntroductionPage5,
    ResaurantsPage,

    Animation_Spread,
    Animation_Method,
    Animation_FeverVoming,
}
public class UIManager : MonoBehaviour
{
    public Transform mParent;
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        OpenPage(EPageType.StartPage);
    }
    Stack<BasePage> mStack = new Stack<BasePage>();
    public GameObject OpenPage(EPageType rType, bool rIsActive = true)
    {
        GameObject go = null;
        switch (rType)
        {
            case EPageType.StartPage:
                go = Instantiate(Resources.Load<GameObject>("UI/StartPage_1"), mParent);
                break;
            case EPageType.IntroductionPage:
                go = Instantiate(Resources.Load<GameObject>("UI/IntroductionPage_2"), mParent);
                break;
            case EPageType.LineUpPage:
                go = Instantiate(Resources.Load<GameObject>("UI/LineUpPage_3"), mParent);
                break;
            case EPageType.AchievementPage:
                go = Instantiate(Resources.Load<GameObject>("UI/AchievementPage_4"), mParent);
                break;
            case EPageType.IntroductionPage5:
                go = Instantiate(Resources.Load<GameObject>("UI/IntroductionPage_5"), mParent);
                break;
            case EPageType.ResaurantsPage:
                go = Instantiate(Resources.Load<GameObject>("UI/RestaurantsPage_6"), mParent);
                break;
            case EPageType.Animation_Spread:
                go = Instantiate(Resources.Load<GameObject>("UI/AnimationPage1_Spread"), mParent);
                break;
            case EPageType.Animation_Method:
                go = Instantiate(Resources.Load<GameObject>("UI/AnimationPage1_Method"), mParent);
                break;
            case EPageType.Animation_FeverVoming:
                go = Instantiate(Resources.Load<GameObject>("UI/AnimationPage1_Fever&vomiting"), mParent);
                break;
            default:
                go = Instantiate(Resources.Load<GameObject>("UI/StartPage_1"), mParent);
                break;
        }
        //go.transform.parent = mParent;
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
        if (rIsActive == false)
        {
            foreach (var item in mStack)
            {
                item.gameObject.SetActive(false);
            }
        }
        mStack.Push(go.GetComponent<BasePage>());

        PlayMusic(rType);
        return go;
    }
    /// <summary>
    /// 关闭最后一个界面 close the interface
    /// </summary>
    public void CloseLastPage()
    {
        if (mStack.Count > 1)
        {
            var item = mStack.Pop();
            DestroyImmediate(item.gameObject);
        }
        var page = mStack.Peek();
        page.gameObject.SetActive(true);
        PlayMusic(page.mPageType);
    }
    /// <summary>
    /// 关闭所有界面 close all
    /// </summary>
    public void CloseAllPage()
    {
        while (mStack.Count > 1)
        {
            var item = mStack.Pop();
            DestroyImmediate(item.gameObject);
        }
        var page = mStack.Peek();
        page.gameObject.SetActive(true);
        PlayMusic(page.mPageType);
        PlayMusic(page.mPageType);
    }
    void PlayMusic(EPageType rType)
    {
        //音乐控制 music control
        if (rType == EPageType.StartPage)
        {
            AudioManager.Instance.PlayMusic1();
        }
        else
        {
            AudioManager.Instance.PlayMusic2();
        }
    }
}

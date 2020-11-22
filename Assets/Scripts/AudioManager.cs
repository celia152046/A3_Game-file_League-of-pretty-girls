using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 声音播放管理器 music control
/// </summary>
public class AudioManager : MonoBehaviour
{
    public AudioSource mBgMusic;
    public static AudioManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// 背景音乐开关 The control button of background music (turn on/off) 
    /// </summary>
    public const string MusicTurn = "_game_musicTurn";
    public bool IsOn()
    {
        return PlayerPrefs.GetInt(MusicTurn, 1) == 1 ? true : false;
    }
    /// <summary>
    /// 设置音乐开关  Set up the control button of background music(turn on/off) 
    /// </summary>
    /// <param name="rIsOn">true: on; false;off</param>
    public void SetMusicTurn(bool rIsOn)
    {
        PlayerPrefs.SetInt(MusicTurn, rIsOn ? 1 : 0);
        if (mBgMusic != null)
        {
            if (rIsOn && mBgMusic.isPlaying == false)
            {
                mBgMusic.Play();
            }
            else
            {
                mBgMusic.Pause();
            }
        }
    }
    /// <summary>
    /// 首页音乐 title page music
    /// </summary>
    public void PlayMusic1()
    {
        mBgMusic.clip = Resources.Load<AudioClip>("封面背景音乐");
        if (IsOn())
        {
            mBgMusic.Play();
        }
    }
    /// <summary>
    /// 其他页面音乐 other pages musics (excpet title page)
    /// </summary>
    public void PlayMusic2()
    {
        //mBgMusic.clip = Resources.Load<AudioClip>("除了封面以外所有地方的背景音乐");
        if (IsOn())
        {
            if (mBgMusic.clip.name != "除了封面以外所有地方的背景音乐")
            {
                mBgMusic.clip = Resources.Load<AudioClip>("除了封面以外所有地方的背景音乐");
            }
            mBgMusic.Play();
        }
    }
    public void StopMusic()
    {
        if (mBgMusic != null)
        {
            mBgMusic.Stop();
        }
        SetMusicTurn(false);
    }
}

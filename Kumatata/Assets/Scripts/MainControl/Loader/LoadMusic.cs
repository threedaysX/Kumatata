using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 每選擇一首歌並開始之後，會開始產生點擊提示
/// </summary>
public class LoadMusic : MonoBehaviour
{
    // 將一首歌以時間為區間 設定時間節點 節點會有提示
    // 主要控制為一個時間條 判斷玩家在哪個時間點點下 符合節奏點即可
    public List<MusicModel> musicItems;

    public Image timerCircle;
    public bool startMusic = false;
    public float timer = 0;

    public AudioSource currentMusic;

    void Update()
    {
        if (startMusic)
        {
            timer += Time.deltaTime;
            AdjustTimerCircle();
        }
    }

    public void GetMusicAndPlay()
    {
        // 根據(選單可選歌)名稱，去讀各種音樂譜面檔案至 musicItems   
        musicItems = GetMusicMap();

        ResetTimerCircle();
        LoadMusicWithTag(tagName: "CurrentMusic");
        PlayMusicOnStart();
    }

    private void LoadMusicWithTag(string tagName)
    {
        GameObject musicObj = GameObject.FindGameObjectWithTag(tagName);
        currentMusic = musicObj.GetComponent<AudioSource>();
    }

    private void PlayMusicOnStart()
    {
        startMusic = true;
        currentMusic.Play();
    }

    private void AdjustTimerCircle()
    {
        var musicTotalLength = currentMusic.clip.length;
        // 依照目前時間占比，調整讀取條。
        timerCircle.fillAmount = Mathf.Clamp(timer / musicTotalLength, 0, 1); 
    }

    private void ResetTimerCircle()
    {
        timerCircle.fillAmount = 0;
        timer = 0;
    }

    /// <summary>
    /// 點擊改成 時間到就觸發熊飢餓(飢餓速度與關卡難度有關，皆正常計算)，並在熊頭上有個觸發的特效。 
    /// </summary>
    /// <returns></returns>
    public List<MusicModel> GetMusicMap()
    {
        return new List<MusicModel>
        {
            new MusicModel(new TimeSpan(0, 0, 3), MusicModel.ClickSide.LeftSide),
            new MusicModel(new TimeSpan(0, 0, 5), MusicModel.ClickSide.LeftSide),
            new MusicModel(new TimeSpan(0, 0, 7), MusicModel.ClickSide.LeftSide),
            new MusicModel(new TimeSpan(0, 0, 9), MusicModel.ClickSide.RightSide),
        };
    }
}

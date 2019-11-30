using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 每選擇一首歌並開始之後，會開始產生點擊提示
/// </summary>
public class MusicGenerator : MonoBehaviour
{
    // 將一首歌以時間為區間 設定時間節點 節點會有提示
    // 主要控制為一個時間條 判斷玩家在哪個時間點點下 符合節奏點即可
    public GenerateBeatHint hintGenerator;
    public List<MusicModel> musicItems;

    public Image timerCircle;
    public bool startMusic = false;
    public float timer = 0;

    public AudioSource currentMusic;

    void Start()
    {
        // 根據(選單可選歌)名稱，去讀各種音樂譜面檔案至 musicItems   
        musicItems = new List<MusicModel>
        {
            new MusicModel(0, 0, 3, MusicModel.ClickSide.LeftSide),
            new MusicModel(0, 0, 5, MusicModel.ClickSide.LeftSide),
            new MusicModel(0, 0, 7, MusicModel.ClickSide.LeftSide),
            new MusicModel(0, 0, 7, MusicModel.ClickSide.RightSide),
        };

        ResetTimerCircle();
        LoadMusicWithTag(tagName: "currentMusic");
        PlayMusicOnStart();
    }

    void Update()
    {
        if (startMusic)
        {
            timer += Time.deltaTime;
            AdjustTimerCircle();
        }
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
        hintGenerator.PlayHintEffect(MusicModel.ClickSide.RightSide);
    }

    private void AdjustTimerCircle()
    {
        timerCircle.fillAmount = Mathf.Clamp(timer, 0, 100); 
    }

    private void ResetTimerCircle()
    {
        timerCircle.fillAmount = 0;
        timer = 0;
    }
}

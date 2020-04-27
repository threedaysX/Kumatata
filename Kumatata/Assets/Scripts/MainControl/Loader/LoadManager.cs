using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public LoadBearWorld loadBearWorld;
    public LoadMusic loadMusic;

    // Start is called before the first frame update
    void Start()
    {
        loadBearWorld = GetComponent<LoadBearWorld>();
        loadMusic = GetComponent<LoadMusic>();

        StartCoroutine(StartLoad());
    }

    IEnumerator StartLoad()
    {
        StartCoroutine(loadBearWorld.LoadBearScene());
        yield return new WaitForSeconds(3f);    // 確保熊場景讀取完畢，等待3秒
        loadMusic.GetMusicAndPlay();
    }
}

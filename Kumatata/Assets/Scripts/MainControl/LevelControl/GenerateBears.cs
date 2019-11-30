using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBears : MonoBehaviour
{
    private int bearsCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        bearsCount = LevelController.maxBearsCount;
    }

    void Update()
    {
        PlayerKeyTrigger();
    }

    private void PlayerKeyTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartGenerateBears();
        }
    }

    private void StartGenerateBears()
    {
        // 熊出沒注意
        // 淡入生成 (位置?)
        // 鏡頭拉進 (對話框)
        // 嘎吼！！  (叫聲)
    }
}

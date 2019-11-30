using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratePlayerFoodBag : MonoBehaviour
{
    public GameObject destCanvas;

    void Awake()
    {
        StartGeneratePlayerFoodBag();
    }

    private void StartGeneratePlayerFoodBag()
    {
        int needToCreateLoopCount = LevelController.maxPlayerFoodCount;
        for (int i = 0; i < needToCreateLoopCount; i++)
        {
            GameObject newImageObj = new GameObject();
            newImageObj.transform.SetParent(destCanvas.transform);
            newImageObj.AddComponent<Image>();
        }
    }
}

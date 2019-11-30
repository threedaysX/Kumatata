using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int maxBearsCount = 0;
    public static int maxPlayerFoodCount = 0;
    public static int musicLevel = 0;
    public static float foodExhuastionLevel = 0f;

    private void Awake()
    {
        GetMaxBearsCount();
        GetPlayerFoodBagMaxSize();
        Debug.Log("熊熊喔: " + maxBearsCount + "隻");
    }

    private void GetMaxBearsCount()
    {
        int tempCcount = 0;
        var rootObj = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject child in rootObj.Where(x => x.tag.Equals("Bear") && 
                                                        x.gameObject.activeSelf))
        {
            tempCcount++;
        }
        maxBearsCount = tempCcount;
    }

    private void GetPlayerFoodBagMaxSize()
    {
        if (maxBearsCount <= 0)
        {
            GetMaxBearsCount();
        }

        if (maxBearsCount - 1 > 0)
        {
            maxPlayerFoodCount = maxBearsCount - 1;
        }
        else
        {
            maxBearsCount = 1;
        }
    }
}

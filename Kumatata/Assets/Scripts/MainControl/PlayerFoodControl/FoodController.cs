using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : Singleton<FoodController>
{
    public GameObject playerFoodBag;
    public static List<Transform> playerFoodList = new List<Transform>();
    private static int _foodStackOrder = 0;
    public static int foodStackOrder
    {
        get
        {
            return (_foodStackOrder > 0) ? _foodStackOrder : 0;
        }
        set
        {
            _foodStackOrder = value;
        }
    }
    public static int playerCanUseFoodCount = 0;

    private void Start()
    {
        playerFoodList = GetPlayerFoodBagList();
        ReloadPlayerFoodBag();
    }

    public List<Transform> GetPlayerFoodBagList()
    {
        List<Transform> tempFoodList = new List<Transform>();
        foreach (Transform food in playerFoodBag.transform)
        {
            tempFoodList.Add(food);
        }
        return tempFoodList;
    }

    public void ReloadPlayerFoodBag()
    {
        playerCanUseFoodCount = 0;
        foreach (Transform food in playerFoodList)
        {
            food.gameObject.SetActive(true);
            if (food.gameObject.activeSelf)
            {
                playerCanUseFoodCount++;
            }
        }
        foodStackOrder = playerFoodList.Count - 1;
    }

    public bool CheckPlayerFoodBag()
    {
        bool result = false;
        if (playerCanUseFoodCount > 0)
        {
            result = true;
        }

        return result;
    }

    public void TakeFoodOutFromPlayerBag()
    {
        if (foodStackOrder >= 0)
        {
            playerFoodList[foodStackOrder].gameObject.SetActive(false);
            foodStackOrder--;
            playerCanUseFoodCount--;
        }
    }
}

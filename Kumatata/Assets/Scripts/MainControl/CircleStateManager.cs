using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleStateManager : Singleton<CircleStateManager>
{
    public void ChangeFoodState(GameObject gameObject, CircleState.FoodCircleState toChangeCircleState)
    {
        var foodCircle = GetFoodCircleStateInfo(gameObject);
        foodCircle.bearCircleState = toChangeCircleState;
    }

    public bool CheckFoodExists(GameObject gameObject)
    {
        bool isFoodFilled = false;
        switch (GetFoodCircleStateInfo(gameObject).bearCircleState)
        {
            case CircleState.FoodCircleState.Empty:
                break;
            case CircleState.FoodCircleState.Filled:
                isFoodFilled = true;
                break;
        }
        return isFoodFilled;
    }

    public CircleState GetFoodCircleStateInfo(GameObject gameObject)
    {
        return gameObject.GetComponent<CircleState>();
    }

    public enum FoodCircleState
    {
        Empty = 0,
        Filled = 1
    }
}

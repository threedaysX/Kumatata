using System;
using System.Collections;
using UnityEngine;

public class BearEat : MonoBehaviour
{
    public BearManager bearManager;
    private bool _OhOhBearsStartToEat = false;
    public bool OhOhBearsStartToEat
    {
        get
        {
            return _OhOhBearsStartToEat;
        }
        set
        {
            _OhOhBearsStartToEat = value;
            if (_OhOhBearsStartToEat)
            {
                foreach (Transform foodObject in bearManager.GetFoodObjectInBearFoodBag())
                {
                    Destroy(foodObject.gameObject);
                    Eating_Animation();
                    Eating_MovePos(foodObject);
                }
            }
        }
    }

    void Start()
    {
        CallEatFood._instance.onPlayerCallToEat.AddListener(DoEatingWork);
    }

    private void DoEatingWork()
    {
        // 頭上有食物，執行動作
        if (CircleStateManager.Instance.CheckFoodExists(bearManager.GetChildObjectByName("FoodCircle")))
        {
            OhOhBearsStartToEat = true;
        }
    }

    private void Eating_MovePos(Transform foodObject)
    {
        var foodWorldPos = foodObject.transform.position;
        // 移動完重置圓狀態
        StartCoroutine(MoveToPosition(this.gameObject.transform, foodWorldPos, 0.4f, Eating_ChangeState));
    }

    private void Eating_ChangeState()
    {
        CircleStateManager.Instance.ChangeFoodState(bearManager.GetChildObjectByName("FoodCircle"), 
                                                    CircleState.FoodCircleState.Empty);
    }

    private void Eating_Animation()
    {
        // 吃吃動畫
        print("OH....." + gameObject.name + " ANIMATION!!");
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 destPosition, float timeToMove, Action callBack = null)
    {
        var currentPos = transform.position;
        transform.LookAt(destPosition);
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            var rotation = (1080f * Time.deltaTime) / timeToMove;
            transform.position = Vector3.Lerp(currentPos, destPosition, t);
            transform.Rotate(rotation, rotation, rotation);
            yield return null;
        }
        transform.eulerAngles = new Vector3(0, 180, 0);
        callBack?.Invoke();
    }
}

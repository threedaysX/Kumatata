using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallEatFood : MonoBehaviour
{
    public static CallEatFood _instance;
    public UnityEvent onPlayerCallToEat;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        onPlayerCallToEat.AddListener(FoodController.Instance.ReloadPlayerFoodBag);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("OH.....ALL BEARS COMING!!");
            onPlayerCallToEat.Invoke();
        }
    }
}

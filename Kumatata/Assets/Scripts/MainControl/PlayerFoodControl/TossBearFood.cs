using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TossBearFood : MonoBehaviour
{
    public GameObject bearFood;
    public UnityEvent onPlayerTossBearFood;
    Ray ray;
    RaycastHit hit;
    FoodController foodController;
    CircleStateManager circleStateManager;

    private void Start()
    {
        bearFood = Resources.Load<GameObject>("Prefab/BearFood");
        foodController = FoodController.Instance;
        circleStateManager = CircleStateManager.Instance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Circle":
                        TossFoodOnBearHead();
                        break;
                    case "FoodArea":
                        TossFoodOnArea();
                        break;
                }
            }
        }
    }

    private void TossFoodOnArea()
    {
        if (foodController.CheckPlayerFoodBag())
        {
            var cloneBearFood = Instantiate(bearFood, hit.point, Quaternion.identity);
            cloneBearFood.transform.SetParent(GameObject.FindGameObjectWithTag("FoodArea").transform);

            foodController.TakeFoodOutFromPlayerBag();
            onPlayerTossBearFood.Invoke();
        }
    }

    private void TossFoodOnBearHead()
    {
        if (!circleStateManager.CheckFoodExists(hit.collider.gameObject) &&
            foodController.CheckPlayerFoodBag())
        {
            var cloneBearFood = Instantiate(bearFood, hit.point, Quaternion.identity);
            cloneBearFood.transform.SetParent(hit.collider.gameObject.transform.parent.Find("BearFoodBag"));

            circleStateManager.ChangeFoodState(hit.collider.gameObject, CircleState.FoodCircleState.Filled);
            foodController.TakeFoodOutFromPlayerBag();
            onPlayerTossBearFood.Invoke();
        }
    }
}

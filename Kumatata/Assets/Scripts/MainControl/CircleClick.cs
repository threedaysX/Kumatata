using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleClick : MonoBehaviour
{
    public GameObject bearFood;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        bearFood = Resources.Load<GameObject>("Prefab/BearFood");
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.tag == "Circle")
            {
                print(hit.collider.name);
                var cloneBearFood = Instantiate(bearFood, hit.point, Quaternion.identity);
                cloneBearFood.transform.parent = hit.collider.gameObject.transform;
            }
        }
    }
}

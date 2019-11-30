using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearManager : MonoBehaviour
{
    public GameObject GetChildObjectByName(string name)
    {
        return this.gameObject.transform.Find(name).gameObject;
    }

    public IEnumerable<Transform> GetFoodObjectInBearFoodBag()
    {
        var bearFoodBag = GetChildObjectByName("BearFoodBag").transform;
        foreach (Transform food in bearFoodBag)
        {
            yield return food;
        }
    }
}

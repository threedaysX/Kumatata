using UnityEngine;

public class CircleState : MonoBehaviour
{
    public BearManager bearManager;
    public ParticleSystem foodCircleEffect;
    private CircleStateManager circleStateManager;
    private FoodCircleState _bearCircleState = FoodCircleState.Empty;
    public FoodCircleState bearCircleState
    {
        get
        {
            return _bearCircleState;
        }
        set
        {
            _bearCircleState = value;
            switch (_bearCircleState)
            {
                case FoodCircleState.Empty:
                    foodCircleEffect.Play();
                    GetMeshColliderOfCircle().enabled = true;
                    break;
                case FoodCircleState.Filled:
                    foodCircleEffect.Stop();
                    GetMeshColliderOfCircle().enabled = false;
                    break;
            }
        }
    }

    public enum FoodCircleState
    {
        Empty = 0,
        Filled = 1
    }

    public MeshCollider GetMeshColliderOfCircle()
    {
        return this.gameObject.GetComponent<MeshCollider>();
    }

    private void Start()
    {
        circleStateManager = CircleStateManager.Instance;
    }

    private void OnTriggerStay(Collider target)
    {
        if (target.tag == "BearFood" && !circleStateManager.CheckFoodExists(this.gameObject))
        {
            circleStateManager.ChangeFoodState(this.gameObject, FoodCircleState.Filled);
            target.transform.SetParent(bearManager.GetChildObjectByName("BearFoodBag").transform);

            // 兩隻熊同時碰到同個食物 要怎麼處理，目前想法 開個共同管理 入Queue 根據距離中心遠近，近的就能搶到食物。
        }
    }
}

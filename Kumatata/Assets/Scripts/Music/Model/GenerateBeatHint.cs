using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBeatHint : MonoBehaviour
{
    private BeatHintModel beatHint;
    // 要產生特效在哪些物件上。 (但這樣會綁在這兩個物件上，所以應該是讓BeatHintModel本身就是GameObject，可以彈性生在各種位置)
    // 多建一個 可以Instantiate(改成儲存位置，將特效方塊用移動的，在各種位置生成特效會比較好) 的Editor，並跟MusicModel一樣，提示也會儲存才對。
    // 建立一個Canvas 紀錄特效的2D相對位置 (使3D的遠近座標是固定位置的 (就不會有遠近座標差))，記錄位置後，再自動固定加上，使2d座標變成3d，存進特效model (BeatHintModel)
    public GameObject leftCenterBeatSide;
    public GameObject rightCenterBeatSide;

    public void PlayHintEffect(MusicModel.ClickSide clickSide)
    {
        switch (clickSide) 
        {
            case MusicModel.ClickSide.LeftSide:
                GetBeatHintObject(leftCenterBeatSide);
                break;
            case MusicModel.ClickSide.RightSide:
                GetBeatHintObject(rightCenterBeatSide);
                break;
            default:
                break;
        }
        
        PlayHintEffect();
    }

    private void GetBeatHintObject(GameObject gameObject)
    {
        beatHint = gameObject.GetComponent<BeatHintModel>();
    }

    private void PlayHintEffect()
    {
        if(beatHint != null)
        {
            beatHint.hintEffect.Play();
        }
    }
}

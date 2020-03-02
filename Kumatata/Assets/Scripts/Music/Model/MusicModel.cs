using System;
using UnityEngine;

public class MusicModel
{
    public TimeSpan TimePoint { get; set; }

    /// <summary>
    /// 滑鼠點擊的方式 (左鍵or右鍵)
    /// </summary>
    public ClickSide MouseClickSide { get; set; }
    public enum ClickSide
    {
        LeftSide = 0,
        RightSide = 1
    }

    public MusicModel(TimeSpan timePoint, ClickSide clickSide)
    {
        TimePoint = timePoint;
        MouseClickSide = clickSide;
    }
}

using UnityEngine;

public class MusicModel
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    /// <summary>
    /// 滑鼠點擊的方式 (左鍵or右鍵)
    /// </summary>
    public ClickSide MouseClickSide { get; set; }
    public enum ClickSide
    {
        LeftSide = 0,
        RightSide = 1
    }

    public MusicModel(int hours, int minutes, int seconds, ClickSide clickSide)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        MouseClickSide = clickSide;
    }
}

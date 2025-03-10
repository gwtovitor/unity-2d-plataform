using DG.Tweening;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{   
    public string groundTag;
    public string playerDeathTrigger = "Death";

    [Header("SpeedSetup")]
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("AnimationSetup")]
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolFalling = "Falling";
    public float playerSwipeDuration = .1f;

}

using System;
using UnityEngine;


[Serializable]
public class MoveSpeedUpgrade : BaseUpgrade
{
    [Tooltip("MoveSpeed multiplier")]
    [SerializeField] private float _multiplier = 1.1f;
    
    public override void Execute(PlayerController player)
    {
        player.IncreaseMoveSpeed(_multiplier);
        Debug.Log("YO");
    }
}


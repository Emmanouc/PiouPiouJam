﻿using UnityEngine;

namespace Gameplay.Weapons
{

    /// <summary>
    /// Represents a lasso with a large AOE
    /// </summary>
    public class WeaponLasso : WeaponBase
    {

        [SerializeField] GameObject _prefab;

        public WeaponLasso()
        {
        }

        public override void Update(PlayerController player)
        {
            _timerCoolDown += Time.deltaTime;

            if (_timerCoolDown < _coolDown)
                return;

            _timerCoolDown -= _coolDown;


            Vector2 position = (Vector2)player.transform.position + Vector2.right * player.DirectionX * 2;

            GameObject go = GameObject.Instantiate(_prefab, position, Quaternion.identity,player.transform);

            go.GetComponent<Bullet>().Initialize(player.Direction,GetDamage(),0);
            go.GetComponent<Bullet>().DontDestroy = true;

        }
    }
}
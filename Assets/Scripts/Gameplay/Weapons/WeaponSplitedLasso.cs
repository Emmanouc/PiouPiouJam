using UnityEngine;

namespace Gameplay.Weapons
{

    /// <summary>
    /// Represents a lasso with a large AOE
    /// </summary>
    public class WeaponSplitedLasso : WeaponBase
    {

        [SerializeField] GameObject _prefab;

        public WeaponSplitedLasso()
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
            GameObject go1 = GameObject.Instantiate(_prefab, position, Quaternion.identity, player.transform);

            go.GetComponent<Bullet>().Initialize(player.Direction,GetDamage(),0);
            go.GetComponent<Bullet>().DontDestroy = true;
            go1.GetComponent<Bullet>().Initialize(-player.Direction, GetDamage(), 0);
            go1.GetComponent<Bullet>().DontDestroy = true;
        }
    }
}
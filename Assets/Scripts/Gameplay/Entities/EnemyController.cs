using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Represents an enemy who's moving toward the player
/// and damage him on collision
/// data bout the enemy are stored in the EnemyData class
/// CAUTION : don't forget to call Initialize when you create an enemy
/// </summary>
public class EnemyController : Unit
{
    GameObject _player;
    Rigidbody2D _rb;
    EnemyData _data;

    public GameObject DeathFX;
    public GameObject Husk;

    private List<PlayerController> _playersInTrigger = new List<PlayerController>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    public void Initialize(GameObject player, EnemyData data)
    {
        _player = player;
        _data = data;
        _life = data.Life;
        _team = 1;
    }

    private void Update()
    {
        if (_life <= 0)
            return;


        foreach (var player in _playersInTrigger)
        {
            player.Hit(Time.deltaTime * _data.DamagePerSeconds);

            FindObjectOfType<AudioManager>().Play("EnemyOuch");
        }
    }

    void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector3 direction = _player.transform.position - transform.position;
        direction.z = 0;

        float moveStep = _data.MoveSpeed * Time.deltaTime;
        if (moveStep >= direction.magnitude)
        {
            _rb.velocity = Vector2.zero;
            transform.position = _player.transform.position;
        }
        else
        {
            direction.Normalize();
            _rb.velocity = direction * _data.MoveSpeed;
        }
    }

    public override void Hit(float damage)
    {
        _life -= damage;
        FindObjectOfType<AudioManager>().Play("EnemyOuch");

        if (Life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        MainGameplay.Instance.Enemies.Remove(this);
        GameObject.Destroy(gameObject);
        GameObject.Instantiate(Husk, transform.position, Quaternion.identity);
        var xp = GameObject.Instantiate(MainGameplay.Instance.PrefabXP, transform.position + new Vector3(0,-0.5f,0), Quaternion.identity);
        xp.GetComponent<CollectableXp>().Initialize(1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var other = HitWithParent.GetComponent<PlayerController>(col);

        if (other != null)
        {
            if (_playersInTrigger.Contains(other) == false)
                _playersInTrigger.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        var other = HitWithParent.GetComponent<PlayerController>(col);

        if (other != null)
        {
            if (_playersInTrigger.Contains(other))
                _playersInTrigger.Remove(other);
        }
    }
}
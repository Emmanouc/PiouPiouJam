using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Represents a bullet moving in a given direction
/// A bullet can be fired by the player or by an enemy
/// call Initialize to set the direction
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] int _team;
    [SerializeField] float _timeToLive = 10.0f;

    public SpriteRenderer Sprite;

    public bool DontDestroy { get; set; }

    float _speed = 10;
    float _damage = 5;
    Vector3 _direction;

    public void Initialize(Vector3 direction , float damage , float speed )
    {
        _direction = direction;
        _speed = speed;
        _damage = damage;

        if (_direction.x < 0.0f)
            Sprite.flipX = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(gameObject, _timeToLive);
    }

    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var other = HitWithParent.GetComponent<Unit>(col);

        if (other == null)
        {
            if (DontDestroy == false)
                GameObject.Destroy(gameObject);
        }
        else if (other.Team != _team)
        {
            if (DontDestroy == false)
                GameObject.Destroy(gameObject);

            other.Hit(_damage);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject DeathFX;
    public float delay;


    void Start()
    {
        StartCoroutine(Delay(delay));
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject Soul = Instantiate(DeathFX, transform.position, DeathFX.transform.rotation);

        ParticleSystem SoulFX = Soul.GetComponent<ParticleSystem>();
        yield return new WaitWhile(() =>SoulFX.isPlaying);

        yield return new WaitForSeconds(60);

        GameObject.Destroy(gameObject);
    }
}

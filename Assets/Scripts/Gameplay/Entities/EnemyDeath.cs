using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject DeathFX;
    public float delay;
    public float ParticleLifetime;


    void Start()
    {
        StartCoroutine(Delay(delay));
    }

    private IEnumerator Delay(float delay)
    {
        Debug.Log("coucou");
        yield return new WaitForSeconds(delay);

        GameObject Soul = Instantiate(DeathFX, transform.position, DeathFX.transform.rotation);
        GameObject.Destroy(Soul, ParticleLifetime);


        yield return new WaitForSeconds(ParticleLifetime);

        GameObject.Destroy(gameObject);
    }
}

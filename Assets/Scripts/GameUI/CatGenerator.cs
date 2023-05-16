using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatGenerator : MonoBehaviour
{
    public GameObject[] PlunkThings;

    public float delay;


    void Start()
    {
        int totalElements = PlunkThings.Count();

        StartCoroutine(Delay(delay, totalElements));
    }

    private IEnumerator Delay(float delay, int totalElements)
    {
        while (true)
        {
            int pick = Random.Range(0, totalElements);

            GameObject Cat = Instantiate(PlunkThings[pick], transform.position , Quaternion.identity);

            yield return new WaitForSeconds(delay);
        }
    }
}
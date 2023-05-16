using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(gameObject, 60.0f);
    }
}

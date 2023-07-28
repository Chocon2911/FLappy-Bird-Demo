using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounting : HuyMonoBehaviour
{
    [SerializeField] protected int score = 0;

    protected void OnTriggerEnter(Collider other)
    {
        if (transform.gameObject.CompareTag("Score")) score++;
    }
}

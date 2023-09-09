using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounting : HaoMonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Score"))
             Score.score++;
    }
}

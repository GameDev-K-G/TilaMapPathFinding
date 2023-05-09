using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffcol : MonoBehaviour
{
    // Start is called before the first frame update
 private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}

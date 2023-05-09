using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour {
    
    private void Start() {
        Debug.Log("Start CollisionLogger on "+this.name);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(this.name + " Trigger 2D with " + other.name + " tag=" + other.tag);
       // Destroy1();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Collider2D other = collision.collider;
        Debug.Log(this.name + " Collision 2D with " + other.name + " tag=" + other.tag);
          //    Destroy1();
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(this.name + " Trigger with name=" + other.name+" tag="+other.tag);
             // Destroy1();
    }

    private void OnCollisionEnter(Collision collision) {
        Collider other = collision.collider;
        Debug.Log(this.name + " Collision with " + other.name + " tag=" + other.tag);
             // Destroy1();
    }
}
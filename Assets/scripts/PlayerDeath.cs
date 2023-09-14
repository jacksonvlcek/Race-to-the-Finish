using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{


[SerializeField] AudioSource enemyDeathSound;
[SerializeField] AudioSource fallDeathSound;

//Prevents multiple death events
bool dead = false;

    //Kills player on enemy collision
   private void OnCollisionEnter(Collision collision)
   {
    if (collision.gameObject.CompareTag("Enemy body"))
    {
          enemyDeathSound.Play();
          GetComponent<MeshRenderer>().enabled = false;
          GetComponent<Rigidbody>().isKinematic = true;
          GetComponent<PlayerMovement>().enabled = false;
          Die();
    }
   }

   //Kills player from falling
   private void Update()
   {
        if (transform.position.y < -4f && !dead) {
          fallDeathSound.Play();
          Die();
        }
   }

   //Kills player and respawns
   void Die()
   {
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
   }

//Relods after death
   void ReloadLevel()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}

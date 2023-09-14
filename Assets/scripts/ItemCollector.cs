using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Allows player to collect items and display how many have been collected
public class ItemCollector : MonoBehaviour
{
    [SerializeField] string item;
    [SerializeField] TMP_Text itemsText;
    [SerializeField] AudioSource collectionSound;

    int items = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(item))
        {
            collectionSound.Play();
            Destroy(other.gameObject);
            items++;

            //Coin text in the top left
            itemsText.text = "Coins: " + items;
        }
    }
}

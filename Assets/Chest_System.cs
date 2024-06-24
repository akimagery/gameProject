using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest_System : MonoBehaviour
{
    public int Coins_Count;

    public Sprite Chest_Open;
    public Sprite Chest_Close;

    [SerializeField] private Hero_System player;

    private bool isOpened = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isOpened == false)
        {
            player.Coins += Coins_Count;
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            gameObject.GetComponent<SpriteRenderer>().sprite = Chest_Open;
            isOpened = true;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().sprite = Chest_Close;
        Destroy(gameObject, 1f);
    }
}

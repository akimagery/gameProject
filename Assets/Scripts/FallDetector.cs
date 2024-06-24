using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
public float deathZone = -10f; // Adjust as needed
private GameObject deathMenu;

void Start() {
        deathMenu = GameObject.Find("Death_Menu");
        deathMenu.SetActive(false);
}
void Update()
{
if (transform.position.y < deathZone)
{
KillPlayer();
}
}
void KillPlayer()
{
// Handle player death (e.g., restart level, lose a life, etc.)
Destroy(gameObject);
Debug.Log("Player died by falling into the void.");
StartCoroutine(waitDeath());


}

public IEnumerator waitDeath()
    {
        yield return new WaitForSeconds(3f);
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}

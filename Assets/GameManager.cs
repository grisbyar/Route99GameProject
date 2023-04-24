using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject spawnPoint;
    
    private GameObject currentPlayer;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (playerPrefab != null && spawnPoint != null)
        {
            // Destroy the current player instance if it exists
            if (currentPlayer != null)
            {
                Destroy(currentPlayer);
            }

            // Instantiate the new player at the spawn point
            currentPlayer = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

    public void RespawnPlayer(float delay)
    {
        StartCoroutine(RespawnPlayerCoroutine(delay));
    }

    private IEnumerator RespawnPlayerCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnPlayer();
    }
}

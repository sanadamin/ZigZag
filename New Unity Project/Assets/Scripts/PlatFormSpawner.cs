using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormSpawner : MonoBehaviour
{
    public AudioClip music;
    public GameObject platform, diamond;
    public bool gameOver = false;

    private Vector3 lastSpawnPosition;
    private float platformSize;
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.Play();
        lastSpawnPosition = platform.transform.position;
        platformSize = platform.transform.localScale.x;
        for (int i = 0; i <= 20; i++)
        {
            SpawnPlatform();
        }

        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
    }

    void SpawnPlatform()
    {
        if (gameOver)
        {
            return;
        }
        int randomNumber = Random.Range(0, 7);
        if (randomNumber < 3)
        {
            SpawnX();
        }
        else if (randomNumber >= 3)
        {
            SpawnZ();
        }
    }

    private void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }
    }

    void SpawnX()
    {
        Vector3 position = lastSpawnPosition;
        position.x += platformSize;
        Instantiate(platform, position, Quaternion.identity);

        int random = Random.Range(0, 4);
        if (random < 1)
        {
            Vector3 position1 = new Vector3(position.x, position.y + 1, position.z);
            Instantiate(diamond, position1, diamond.transform.rotation);
        }
        lastSpawnPosition = position;
    }
    void SpawnZ()
    {
        Vector3 position = lastSpawnPosition;
        position.z += platformSize;
        Instantiate(platform, position, Quaternion.identity);
        int random = Random.Range(0, 4);
        if (random < 1)
        {
            Vector3 position1 = new Vector3(position.x, position.y + 1, position.z);
            Instantiate(diamond, position1, diamond.transform.rotation);
        }
        lastSpawnPosition = position;
    }
}

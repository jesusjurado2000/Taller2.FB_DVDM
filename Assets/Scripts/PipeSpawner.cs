using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float timeBetweenSpawns = 2f;
    private float timeSinceLastSpawn = 0f;
    public string pipeTag = "Pipe";
    public Transform spawnPosition;
    public float minHeight = -1f;
    public float maxHeight = 3f;
    [SerializeField] private GameSettingsController gameSettingsController;

    void Update()
    {
        if (GameManager.Instance.InicioJuego == true)
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= timeBetweenSpawns)
            {
                SpawnPipe();
                timeSinceLastSpawn = 0f;
            }
        }
    }

    void SpawnPipe()
    {
        string selectedPoolTag;

        if (gameSettingsController.selectedTimeOfDay == "Day")
        {
            selectedPoolTag = "DayPipe";
            Debug.Log("day pipe");
        }
        else
        {
            selectedPoolTag = "NightPipe";
            Debug.Log("night pipe");

        }
        float spawnYPosition = Random.Range(minHeight, maxHeight);
        Vector3 spawnPos = new Vector3(spawnPosition.position.x, spawnYPosition, spawnPosition.position.z);
        ObjectPooler.Instance.SpawnFromPool(selectedPoolTag, spawnPos, Quaternion.identity);

    }
}

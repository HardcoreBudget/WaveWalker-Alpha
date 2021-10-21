using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject player;
    const float PLAYER_SPAWN_MINE_DISTANCE=25;
    float offset;
    Vector2 spawnPosition;
    float xSpawn;
    float ySpawn;
    Vector3 cameraPos;
    Vector3 previousCameraPos;
    int Score;
    [SerializeField] Text scoreText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPosition.x = player.transform.position.x + 5;
        cameraPos = transform.position;
        offset = cameraPos.x - player.transform.position.x;
        cameraPos.x = player.transform.position.x + offset;
        previousCameraPos = cameraPos;
        
    }
    // Update is called once per frame
    void Update()
    {        
        cameraPos.x = player.transform.position.x + offset;
        Score += (int)cameraPos.x - (int)previousCameraPos.x;
        scoreText.text = Score.ToString();
        previousCameraPos = cameraPos;
        if (Mathf.Abs(player.transform.position.x - spawnPosition.x) < PLAYER_SPAWN_MINE_DISTANCE)
            SpawnMine();
        transform.position = cameraPos;
    }

    void SpawnMine()
    {
        xSpawn = spawnPosition.x + (int) Random.Range(0,4);
        ySpawn = (int) Random.Range(-4, 5f);
        spawnPosition = new Vector2(xSpawn, ySpawn);

        Instantiate((GameObject)Resources.Load("Mine"), spawnPosition, Quaternion.identity);
    }

}

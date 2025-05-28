using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 1/2;
    private float timer = 0;
    public float heightOffset = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(pipe, transform); 
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 1 / spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            float lowestPoint = transform.position.y - heightOffset;
            float highestPoint = transform.position.y + heightOffset;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation); 
            timer = 0;
        }
    }
}

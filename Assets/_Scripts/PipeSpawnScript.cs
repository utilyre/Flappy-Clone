using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject Pipe;
    [SerializeField] float SpawnRate = 1 / 2;
    [SerializeField] float Height = 10;

    float m_Timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(Pipe, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Timer < 1 / SpawnRate)
        {
            m_Timer += Time.deltaTime;
        }
        else
        {
            float lowestPoint = transform.position.y - Height;
            float highestPoint = transform.position.y + Height;
            Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
            m_Timer = 0;
        }
    }
}

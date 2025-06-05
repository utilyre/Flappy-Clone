using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipe;
    [SerializeField] private float _spawnRate = 1 / 2;
    [SerializeField] private float _height = 10;

    private float m_Timer = 0;

    private void Start()
    {
        SpawnPipeAtRandomHeight();
    }

    private void Update()
    {
        if (m_Timer < 1 / _spawnRate)
        {
            m_Timer += Time.deltaTime;
        }
        else
        {
            SpawnPipeAtRandomHeight();
            m_Timer = 0;
        }
    }

    private void SpawnPipeAtRandomHeight()
    {
        float lowestPoint = transform.position.y - _height;
        float highestPoint = transform.position.y + _height;
        Instantiate(_pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }
}

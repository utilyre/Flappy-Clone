using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipe;
    [SerializeField] private float _spawnRate = 1 / 2;
    [SerializeField] private float _height = 10;

    private float m_Timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Instantiate(_pipe, transform);
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_Timer < 1 / _spawnRate)
        {
            m_Timer += Time.deltaTime;
        }
        else
        {
            float lowestPoint = transform.position.y - _height;
            float highestPoint = transform.position.y + _height;
            Instantiate(_pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
            m_Timer = 0;
        }
    }
}

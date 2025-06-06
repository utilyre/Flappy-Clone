using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipe;
    [Tooltip("The duration between each spawn in seconds.")]
    [SerializeField] private float _spawnInterval = 2;
    [SerializeField] private float _height = 10;

    private float _timer = 0;

    private void Start()
    {
        SpawnPipeAtRandomHeight();
    }

    private void Update()
    {
        // possible to use async/await but it might not be all that necessary
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0;
            SpawnPipeAtRandomHeight();
        }
    }

    private void SpawnPipeAtRandomHeight()
    {
        float lowestPoint = transform.position.y - _height;
        float highestPoint = transform.position.y + _height;
        Instantiate(_pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }
}

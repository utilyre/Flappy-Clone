using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private GameObject _doubleScorePowerUpPrefab;
    [SerializeField] private GameObject _gunPowerUpPrefab;

    [Tooltip("The duration between each spawn in seconds.")]
    [SerializeField] private float _spawnInterval = 2;
    [SerializeField] private float _height = 10;
    [SerializeField] private float _doubleScorePowerUpProbability = 0.01f;
    [SerializeField] private float _gunPowerUpProbability = 0.2f;

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
        var spawnPosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint));

        Instantiate(_pipePrefab, spawnPosition, transform.rotation);

        if (Random.Range(0.0f, 1.0f) < _doubleScorePowerUpProbability)
        {
            Instantiate(_doubleScorePowerUpPrefab, spawnPosition, transform.rotation);
        }
        else if (Random.Range(0.0f, 1.0f) < _gunPowerUpProbability)
        {
            Instantiate(_gunPowerUpPrefab, spawnPosition, transform.rotation);
        }
    }
}

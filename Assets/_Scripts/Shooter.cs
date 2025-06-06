using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 10;
    [SerializeField] private Vector3 _offset = new();

    private float _fireTimer;

    void Update()
    {
        _fireTimer += Time.deltaTime;
        if (_fireTimer >= 1.0f / _fireRate)
        {
            _fireTimer = 0;
            Instantiate(
                _bulletPrefab,
                transform.position + _offset,
                Quaternion.Euler(0, 0, -90)
            );
        }
    }
}

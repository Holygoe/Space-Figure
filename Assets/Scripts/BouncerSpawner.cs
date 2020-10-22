using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace RudeBlooper.SpaceFigure
{
    public class BouncerSpawner : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] private Bouncer _bouncerPrefab;
        [SerializeField] private Vector2 _startBouncerVelocity;
        [SerializeField] private float _spawnRate = 0.2f;
        [SerializeField] private int _spawnCount = 10;
#pragma warning restore CS0649

        private IEnumerator Start()
        {
            var count = 0;
            var waitForNextSpawn = new WaitForSeconds(_spawnRate);

            while (count < _spawnCount)
            {
                var bouncer = Instantiate(_bouncerPrefab, transform.position, Quaternion.identity);
                bouncer.SetStartVelocity(_startBouncerVelocity);
                count++;
                yield return waitForNextSpawn;
            }
            
            Destroy(gameObject);
        }

        private void Update()
        {
            
        }
    }
}

using UnityEngine;

namespace RudeBlooper.SpaceFigure
{
    public class Bouncer : MonoBehaviour
    {
        private const float MIN_SCALE = 0.4f;
        
#pragma warning disable CS0649
        [SerializeField] private int _startLife = 100;
#pragma warning restore CS0649

        private Rigidbody2D _rigidbody;

        private int _life;

        private float _scaleShare;

        private Vector2 _startVelocity;

        public void SetStartVelocity(Vector2 velocity)
        {
            _startVelocity = velocity;
        }
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = _startVelocity;
            _life = _startLife;
            _scaleShare = (transform.localScale.x - MIN_SCALE) / _startLife;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag(Tags.FIGURE))
            {
                var figure = other.collider.GetComponent<Figure>();
                figure.Hit();
            }

            _life--;
            transform.localScale = (MIN_SCALE + _scaleShare * _life) * Vector3.one;

            if (_life == 0) Destroy(gameObject);
        }
    }
}

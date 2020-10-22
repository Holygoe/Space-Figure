using System.Collections;
using UnityEngine;

namespace RudeBlooper.SpaceFigure
{
    public class Figure : MonoBehaviour
    {
        private const float HIT_RATE = 4f;

        private const float SWOLLEN_SCALE = 1.5f;

        private bool _hit;
        
        public void Hit()
        {
            if (_hit) return;

            _hit = true;
            StartCoroutine(HitAsync());
        }

        private IEnumerator HitAsync()
        {
            var thisTransform = transform;
            var waitForEndOfFrame = new WaitForEndOfFrame();

            while (thisTransform.localScale.x < SWOLLEN_SCALE)
            {
                thisTransform.localScale += Time.deltaTime * HIT_RATE * Vector3.one;
                yield return waitForEndOfFrame;
            }

            while (thisTransform.localScale.x > 0)
            {
                thisTransform.localScale -= Time.deltaTime * HIT_RATE * Vector3.one;
                yield return waitForEndOfFrame;
            }
            
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;

namespace Models
{
    public class Coin : MonoBehaviour
    {
        private const float CoinCollectionCooldown = 1f;
        private bool _isCoinCollectable;
        private void OnEnable()
        {
            _isCoinCollectable = false;
            StartCoroutine(CoinCooldown());
        }

        private void Update()
        {
            transform.Rotate(0,0,1.5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player") || !_isCoinCollectable) return;
            
            GameManager.Instance.GainCoin();
            ObjectPool.Recycle(this);
        }
        
        private IEnumerator CoinCooldown()
        {
            var duration = CoinCollectionCooldown;
            float normalizedTime = 0;
            while(normalizedTime <= CoinCollectionCooldown)
            {
                normalizedTime += Time.deltaTime / duration;
                yield return null;
            }

            _isCoinCollectable = true;
            yield return null;
        }
    }
}

using TMPro;
using UnityEngine;

namespace Views
{
    public class Upgrade : MonoBehaviour
    {
        public TextMeshProUGUI coinText;

        private bool _isUpgradeOpen;
        void Start()
        {
            coinText.text = GameManager.Instance.coin + "$";
            GameManager.CoinChanged += UpdateCoin;
        }

        public void OpenUpgrade() //todo: Find better name
        {
            if (_isUpgradeOpen)
            {
                transform.position -= new Vector3(0, 100, 0);
            }
            else
            {
                transform.position += new Vector3(0, 100, 0);
            }

            _isUpgradeOpen = !_isUpgradeOpen;
        }

        private void UpdateCoin(int coin)
        {
            coinText.text = coin + "$";
        }
    }
}

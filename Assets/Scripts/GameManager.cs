using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;
 
    public static GameManager Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = (GameManager)FindObjectOfType(typeof(GameManager));

            if (_instance != null) return _instance;
            var singletonObject = new GameObject();
            _instance = singletonObject.AddComponent<GameManager>();

            return _instance;
        }
    }

    #endregion

    public static event Action<int> LevelChanged;
    public static event Action<int> ExpChanged;
    public static event Action<int> CoinChanged;

    public int exp;
    public int expToLevel;
    public int level;
    public int coin;

    public void GainExp()
    {
        exp += level;
        ExpChanged?.Invoke(exp);

        if (exp < expToLevel) return;
        
        exp %= expToLevel;
        level++;
        expToLevel *= level;
        LevelChanged?.Invoke(level);
        ExpChanged?.Invoke(exp);
    }

    public void GainCoin()
    {
        coin++;
        CoinChanged?.Invoke(coin);
    }
}

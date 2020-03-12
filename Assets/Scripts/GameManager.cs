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

    public static event Action<int> levelChanged;
    public static event Action<int> expChanged;

    public int exp;
    public int expToLevel;
    public int level;

    public void GainExp()
    {
        exp += level;
        expChanged?.Invoke(exp);

        if (exp < expToLevel) return;
        
        exp %= expToLevel;
        level++;
        expToLevel *= level;
        levelChanged?.Invoke(level);
        expChanged?.Invoke(exp);
    }
}

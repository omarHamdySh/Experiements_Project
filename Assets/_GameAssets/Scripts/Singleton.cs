using UnityEngine;
using UnityEngine.Assertions;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                Assert.IsNotNull(_instance);
            }
            return _instance;
        }
    }

    private void OnDestroy()
    {
        if (_instance != null && _instance.gameObject == gameObject)
        {
            _instance = null;
        }
    }
}
using UnityEngine;

abstract public class PersistentSingletonBehaviour<T> : MonoBehaviour where T : PersistentSingletonBehaviour<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(this);
        }
        else
        {
            Instance = (T)this;
            DontDestroyOnLoad(this);
        }
    }
}

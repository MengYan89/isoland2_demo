using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance => Singleton<T>.instance;

    protected virtual void Awake()
    {
        if (Singleton<T>.instance != null)
            Object.Destroy((Object)((Component)this).gameObject);
        else
            Singleton<T>.instance = (T)this;
    }
}

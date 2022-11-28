using UnityEngine;

public class SingletoneHero : MonoBehaviour
{
    private static SingletoneHero _singletoneHero;

    public static SingletoneHero singletoneHero
    {
        get
        {
            if (_singletoneHero == null)
            {
                print("clasSingletonObject+DontDestroy");
                _singletoneHero = GameObject.FindObjectOfType<SingletoneHero>();
                DontDestroyOnLoad(_singletoneHero.gameObject);
            }
            return _singletoneHero;
        }
    }

    void Awake()
    {
        if (_singletoneHero == null)
        {
            print("SingeltonAwake_DontDestroy");
            _singletoneHero = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (this != _singletoneHero)
         {
             print("SingeltonAwake_Destroy");
             Destroy(this.gameObject);
         }
        /*else
        {
            if (_singletoneHero != this)
            {
                print("SingeltonAwake_Destroy");
                Destroy(gameObject);
           }
        }   */  
    }
   }

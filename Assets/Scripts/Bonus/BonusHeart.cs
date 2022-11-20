using UnityEngine;

public class BonusHeart: MonoBehaviour
{
    public GameObject objectBonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            NewObject();
            Destroy(gameObject);
        }
    }

      void NewObject()
    {
        GameObject newobjectBonus = Instantiate(objectBonus);
        newobjectBonus.transform.position = new Vector3(9.5f, 2.5f, 0);
    }
}


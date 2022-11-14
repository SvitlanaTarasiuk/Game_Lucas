using UnityEngine;

public class BonusDiamond: MonoBehaviour
{
    public GameObject objectBonus;

    private void OnCollisionEnter2D(Collision2D collision)
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
        newobjectBonus.transform.position = new Vector3(29.2f, 2f, 0);
    }
}


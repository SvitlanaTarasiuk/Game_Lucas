using UnityEngine;

public class BonusBubble: MonoBehaviour
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
        newobjectBonus.transform.position = new Vector3(33.44f, 0.35f, 0);
    }
}


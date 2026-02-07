using UnityEngine;

public class People : MonoBehaviour
{
    private void Start()
    {
        //Die();
    }
    public void Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
        gameObject.GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
    }
}

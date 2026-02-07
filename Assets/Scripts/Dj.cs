using UnityEngine;

public class Dj : MonoBehaviour
{
    public void EndGame()
    {
        gameObject.GetComponent<Animator>().SetTrigger("End");
    }
}

using UnityEngine;

public class FinalAnimation : MonoBehaviour
{
    [SerializeField] GameObject[] people;

    public void GameEnd()
    {
        foreach (GameObject person in people)
        {
            person.GetComponent<People>().Die();
        }
    }
}

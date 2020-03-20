using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour, ISpawn
{
    [SerializeField] private GameObject[] targetsPrefab = null;
    [SerializeField] private float radiusRange = 5f;

    public void All(int enemyNumber)
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            int index = Random.Range(0, targetsPrefab.Length);
            Instantiate(targetsPrefab[index], GeneratePosition(), targetsPrefab[index].transform.rotation);
        }
    }

    private Vector3 GeneratePosition()
    {
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector2 pos2d = new Vector2(Mathf.Sin(angle) * radiusRange, Mathf.Cos(angle) * radiusRange);
        float y = Random.Range(1f, 10f);

        return new Vector3(pos2d.x, y, pos2d.y);
    }
}

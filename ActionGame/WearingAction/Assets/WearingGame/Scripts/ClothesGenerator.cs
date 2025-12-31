using UnityEngine;

public class ClothesGenerator : MonoBehaviour
{
    [SerializeField, Header("¶¬‚·‚é•‚Ìí—Ş")]
    private GameObject[] wearPrefabs;

    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        maxX = GameObject.Find("Player").GetComponent<PlayerController>().maxX;
        InvokeRepeating("GenerateCloth", 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// •‚ğ¶¬
    /// </summary>
    private void GenerateCloth()
    {
        int randIdx = Random.Range(0, wearPrefabs.Length);
        float posX = Random.Range(-maxX, maxX);

        Instantiate(wearPrefabs[randIdx], new Vector3(posX, 7, 0), Quaternion.identity);
    }
}

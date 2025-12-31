using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField, Header("プレイヤーのスクリプト")]
    private PlayerController playerController;
    [SerializeField, Header("ブロックのPrefab")]
    private GameObject[] blocks;
    [SerializeField, Header("GameControllerオブジェクト")]
    private GameObject gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        // 3秒ごとに呼び出す
        InvokeRepeating("SpawnBlock", 1f, 3f);
    }

    /// <summary>
    /// ブロックを生成する関数
    /// </summary>
    private void SpawnBlock()
    {
        int index = Random.Range(0, blocks.Length);     // 生成するブロックを決定
        Vector3 spawnPos = new Vector3(blocks[index].transform.position.x, playerController.GetGroundLine(), 0);

        // GameControllerの子として生成
        Instantiate(blocks[index], spawnPos, Quaternion.identity, gameController.transform);
    }
}

using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField, Header("ブロック生成スクリプト")]
    private GameObject blockManager;
    [SerializeField, Header("スコア表示UI")]
    private TextMeshProUGUI scoreText;

    private int score;      // スコア
    private bool IsStart;   // スタートフラグ

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        // 初期化処理
        score = 0;
        IsStart = false;
        blockManager.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // スタート処理
        if(Input.GetKeyDown(KeyCode.Space) && IsStart == false)
        {
            Debug.Log("ゲームスタート");
            blockManager.SetActive(true);
        }

        // 終了処理
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ゲーム終了");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }

        scoreText.text = "Score : " + score.ToString("D3");
    }

    /// <summary>
    /// スコアを増やす
    /// </summary>
    public void AddScore()
    {
        score++;
    }
}

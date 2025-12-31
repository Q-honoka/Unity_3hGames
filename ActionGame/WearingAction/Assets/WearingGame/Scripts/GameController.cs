using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEnd;

    [SerializeField, Header("スライダー")]
    private Slider slider;
    [SerializeField, Header("スコア表示テキスト")]
    private TextMeshProUGUI scoreText;
    [SerializeField, Header("スコアアップの間隔")]
    private float scoreUpTime = 1f;
    [SerializeField,Header("リトライメッセージテキスト")]
    private TextMeshProUGUI RetryText;

    private bool isCool;
    private int score;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;


        isCool = false;
        score = 0;
        isEnd = false;
        RetryText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnd)
        {
            timer += Time.deltaTime;
            if (isCool)
            {
                slider.value -= 0.001f;
            }
            else
            {
                slider.value += 0.001f;
            }

            // ゲームオーバー判定・スコアアップ
            if (slider.value <= 0 || slider.value >= 1)
            {
                isEnd = true;
            }
            else if (slider.value >= 0.3 && slider.value <= 0.8 && timer > scoreUpTime)
            {
                score += 10;
                timer = 0;
            }

            score = Mathf.Clamp(score, 0, 99999);
            scoreText.text = "Score:" + score.ToString("D5");
        }
        else
        {
            RetryText.enabled = true;

            // ゲームオーバー処理
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("WearingAction");
            }
        }
    }

    /// <summary>
    /// モードを変える
    /// </summary>
    /// <param name="tempHot"></param>
    public void ChangeMode(bool tempHot)
    {
        if(tempHot)
        {
            isCool = false;
        }
        else
        {
            isCool = true;
        }
    }

    /// <summary>
    /// タイプを返す
    /// </summary>
    /// <returns></returns>
    public FACETYPE GetMode()
    {
        if(slider.value >= 0.8f)
        {
            return FACETYPE.HOT;
        }
        else if(slider.value <= 0.3f)
        {
            return FACETYPE.COLD;
        }
        else
        {
            return FACETYPE.NORMAL;
        }
    }
}

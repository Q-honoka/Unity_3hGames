using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("プレイヤーを追従するカメラ")]
    private Camera cam;
    [SerializeField, Header("ジャンプ力")]
    private float jumpForce = 300;

    private bool IsJump;        // ジャンプフラグ
    private Rigidbody2D rb;     // Rigidbody
    private Vector3 camPos;     // カメラのポジション
    private Vector3 plPos;      // プレイヤーのポジション
    private float GroundLine;   // 地面のライン

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理
        IsJump = false;
        transform.position = new Vector3(0, -4, 0);
        rb = GetComponent<Rigidbody2D>();
        camPos = cam.transform.position;
        plPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されたらジャンプする
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(IsJump == false)
            {
                PlayerJump();
            }
        }

        // カメラの追従処理
        CameraMove();
    }

    /// <summary>
    /// プレイヤーのジャンプ関数
    /// </summary>
    private void PlayerJump()
    {
        Vector2 force = new Vector2(0, jumpForce);  //y軸方向のみ数値を加える
        rb.AddForce(force);
        IsJump = true;
    }

    /// <summary>
    /// カメラの追従処理
    /// </summary>
    private void CameraMove()
    {
        plPos = transform.position;
        camPos = cam.transform.position;

        // プレイヤーの座標が一定値を超えたら
        if(plPos.y >  camPos.y)
        {
            camPos.y = plPos.y;
            cam.transform.position = camPos;    // カメラのポジションを更新する
        }
    }

    /// <summary>
    /// 地面との接地判定
    /// </summary>
    /// <param name="collision"></param>

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 地面と接触したら地面のラインを更新する
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsJump = false;
            GroundLine = transform.position.y;
        }
    }

    /// <summary>
    /// 地面の高さを返す関数
    /// </summary>
    /// <returns></returns>
    public float GetGroundLine()
    {
        return GroundLine;
    }
}

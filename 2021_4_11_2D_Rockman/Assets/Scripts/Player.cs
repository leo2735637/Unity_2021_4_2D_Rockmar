
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位

    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int jump = 100;
    [Range(0, 200)]
    public float hp = 100f;
    [Header("是否在地板上"), Tooltip("地板")]
    public bool floor = false;
    [Header("子彈"), Tooltip("子彈")]
    public GameObject bullet;
    [Header("元件子彈生成點"), Tooltip("子彈生成點")]
    public Transform Bulletgenerate;
    [Range(0, 5000)]
    public int bulletSpeed = 800;
    [Header("開槍音效"), Tooltip("槍聲")]
    public AudioClip Gunshots;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion

    #region 事件

    private void Start()
    {
        //  利用程式取的元件
        //  傳回元件  取的元件<元件名稱>() - <泛型>
        //  取得跟此腳本同一層的元件
        rig = GetComponent<Rigidbody2D>();

    }

    //一秒約執行 60 次
    private void Update()
    {
        Move();
        Jump();
    }

    [Header("判斷地板碰撞的位移與半徑")]
    public Vector3 groundOffset;
    public float groundRadius = 0.2f;
    
    //  繪製圖示 - 輔助編輯的圖形線條
    private void OnDrawGizmos()
    {
        //  1.  指定顏色
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        //  2.  繪製圖形
        //  Gizmos.DrawSphere(Vector3.zero, 2);
        //  transform 可以抓到此腳本同意成的變形元件
        Gizmos.DrawSphere(transform.position + groundOffset, groundRadius);
    }

    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 1. 要抓到玩家安下左右鍵的資訊 Input
        float h = Input.GetAxis("Horizontal");
        print("水平的值：" + h);
        // 2. 使用左右鍵的資訊控制角色移動
        // 剛體.加速度 = 二維向量(水平 * 速度 * 一幀(念正)的時間，指定回原本的 Y 軸加速度)
        // 一幀的時間 - 解決不同效能的裝置速度差的問題
        rig.velocity = new Vector2(h * speed * Time.deltaTime, rig.velocity.y);

    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        //  如果 玩家 按下 空白鍵 就往上跳躍
        //  判斷式 C# 
        //  傳回值為布林值的方法可以當成布林值使用
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  剛體.添加推力(二維向量)
            rig.AddForce(new Vector2(0, jump));
        }
        
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">造成的傷害</param>
    private void Hit(float damage)
    {

    }
    /// <summary>
    /// 死亡
    /// </summary>
    /// <returns>是否死亡</returns>
    private bool Dead()
    {
        return false;
    }

    // <summary>
    /// 吃道具
    /// </summary>
    /// <param name="prop">道具的名稱</param>
    private void Eatprop(string prop)
    {
       
    }

    #endregion


}

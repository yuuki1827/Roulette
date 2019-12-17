using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    // 回転速度
    float rotSpeed;

    // 切り替え判定
    bool stop;

    void Start()
    {
        // 回転速度(初期値)
        rotSpeed = 0;

        // 切り替え判定(初期値は停止)
        stop = true;
    }

    void Update()
    {

        // 左クリックをしたら回転に切り替える
        if (Input.GetMouseButtonDown(0))
        {
            stop = false;
        }
        // 右クリックをしたら停止に切り替える
        else if (Input.GetMouseButtonDown(1))
        {
            stop = true;
        }

        // 回転・減速処理
        switch (stop)
        {
            // 判定が「回転」の場合
            case false:        
                this.rotSpeed = 20;
                break;
            // 判定が「停止」の場合
            case true:
                this.rotSpeed *= 0.96f;
                break;
        }

        /*
         * GetMouseButtonDown = マウスがクリックされた瞬間に「TRUE」を返す
         * GetMouseButtonUp = マウスボタンが離された瞬間に「TRUE」を返す
         * GetMouseButton = マウスがクリックされている間は「TRUE」を返す
         */

        // 回転速度分、ルーレットを回転させる
        transform.Rotate(0, 0, this.rotSpeed);

        /*
         * Rotate = 回転メソッド
         * (X軸回転, Y軸回転, Z軸回転)
         */

        // 停止と初期化
        if (rotSpeed < 0.01)
        {
            Start();
        }
    }
}
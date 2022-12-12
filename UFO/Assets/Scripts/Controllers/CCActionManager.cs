﻿using UnityEngine;

namespace HitUFO
{
    public class CCActionManager : IActionManager
    {
        private class CCAction : MonoBehaviour
        {
            void Update()
            {
                // 关键！当飞碟被回收时，销毁该运动学模型。
                if (transform.position == UFOFactory.invisible)
                {
                    Destroy(this);
                }
                var model = gameObject.GetComponent<UFOModel>();
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3f + model.GetID() * 2f, 10f, -2f), 5 * Time.deltaTime);
            }
        }

        public void SetAction(GameObject ufo)
        {
            // 由于预设使用了 Rigidbody ，故此处取消重力设置。
            ufo.GetComponent<Rigidbody>().useGravity = false;
            // 添加运动学（转换）运动。
            ufo.AddComponent<CCAction>();
        }
    }
}
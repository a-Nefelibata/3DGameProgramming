using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myTween {
    public static class Extension
    {
        //MonoBehaviour的DoMove方法拓展
        public static IEnumerator DoMove(this MonoBehaviour mono, Tween tween)
        {
            Vector3 speed = (tween.target - tween.transform.position) / tween.duration;
            for (float f = tween.duration; f >= 0.0f; f -= Time.deltaTime)
            {
                tween.transform.Translate(speed * Time.deltaTime);
                yield return null;
                while (tween.isPause == true)
                {
                    yield return null;
                }
            }
            tween.runOnComplete();
        }

        //Transform的DoMove方法拓展
        public static Tween DoMove(this Transform transform, Vector3 target, float duration)
        {
            MonoBehaviour mono = transform.GetComponents<MonoBehaviour>()[0];
            Tween tween = new Tween("DoMove",target, duration, transform,null);
            Coroutine coroutine = mono.StartCoroutine(mono.DoMove(tween));
            tween.setCoroutine(coroutine);
            return tween;
        }

        //MonoBehaviour的DoScale方法拓展
        public static IEnumerator DoScale(this MonoBehaviour mono, Tween tween)
        {
            Vector3 speed = (tween.target - tween.transform.localScale) / tween.duration;
            for (float f = tween.duration; f >= 0.0f; f -= Time.deltaTime)
            {
                tween.transform.localScale = tween.transform.localScale + speed * Time.deltaTime;
                yield return null;
                while (tween.isPause == true)
                {
                    yield return null;
                }
            }
            tween.runOnComplete();
        }

        //Transform的DoScale方法拓展
        public static Tween DoScale(this Transform transform, Vector3 target, float time)
        {
            MonoBehaviour mono = transform.GetComponents<MonoBehaviour>()[0];
            Tween tween = new Tween("DoScale", target, time, transform, null);
            Coroutine coroutine = mono.StartCoroutine(mono.DoScale(tween));
            tween.setCoroutine(coroutine);
            return tween;
        }

        //MonoBehaviour的DoRotate方法拓展
        public static IEnumerator DoRotate(this MonoBehaviour mono, Tween tween)
        {
            Vector3 angle = (tween.target - tween.transform.rotation.eulerAngles) / tween.duration;
            for (float f = tween.duration; f >= 0.0f; f -= Time.deltaTime)
            {
                tween.transform.Rotate (angle * Time.deltaTime);
                //tween.transform.rotation = Quaternion.Lerp(tween.original_rotation, tween.target_rotation, 1.0f-f/tween.duration);
                yield return null;
                while (tween.isPause == true)
                {
                    yield return null;
                }
            }
            tween.runOnComplete();
        }

        //Transform的DoRotate方法拓展
        public static Tween DoRotate(this Transform transform, Vector3 target, float time)
        {
            MonoBehaviour mono = transform.GetComponents<MonoBehaviour>()[0];
            Tween tween = new Tween("DoRotate", target, time, transform,null);
            Coroutine coroutine = mono.StartCoroutine(mono.DoRotate(tween));
            tween.setCoroutine(coroutine);
            return tween;
        }

        /*
        //MonoBehaviour的DoColor方法拓展
        public static IEnumerator DoColor(this MonoBehaviour mono, Tween tween)
        {
            float lerp = Mathf.PingPong(Time.time, tween.duration) / tween.duration;
            tween.mat.color = Color.Lerp(tween.mat.color, tween.targetColor, lerp);
            yield return null;
            while (tween.isPause == true)
            {
                yield return null;
            }

            
            //Color colorSwitch = (tween.target - tween.material.)
            //Vector3 speed = (tween.target - tween.transform.localScale) / tween.duration;
            for (float f = tween.duration; f >= 0.0f; f -= Time.deltaTime)
            {
                mono.GetComponent<Renderer>.material.color = Color.Lerp(colorStart, colorEnd, lerp);
                //tween.transform.localScale = tween.transform.localScale + speed * Time.deltaTime;
                yield return null;
                while (tween.isPause == true)
                {
                    yield return null;
                }
            }
            
            tween.runOnComplete();
        }

        //Material的DoColor方法拓展
        public static Tween DoColor(this Material mat, Transform transform, Color targetColor, float time)
        {
            
            float lerp = Mathf.PingPong(Time.time, time)/time;
            mat.color = Color.Lerp(mat.color, targetColor, lerp);
            

            MonoBehaviour mono = transform.GetComponents<MonoBehaviour>()[0];
            Tween tween = new Tween("DoColor", targetColor, time, mono.GetComponent<Renderer>().material,null);
            Coroutine coroutine = mono.StartCoroutine(mono.DoColor(tween));
            tween.setCoroutine(coroutine);
            return tween;
        }
        */
    }
}

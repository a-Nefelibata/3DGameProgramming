using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace myTween
{
    public class Tween
    {
        internal string tid;
        internal Vector3 target;
        internal float duration;
        internal bool isPause = false;
        internal bool isAutoKill = true;
        internal Coroutine coroutine = null;
        internal Transform transform = null;
        public delegate void OnComplete();
        internal OnComplete onComplete = null;

        /*
        internal Color targetColor;
        internal Material mat = null;
        */

        //internal MeshRender msr;

        //public Quaternion original_rotation;
        //public Quaternion target_rotation;

        //constructor
        public Tween(string tid, Vector3 target, float duration, Transform transform, Coroutine coroutine)
        {
            this.tid = tid;
            this.target = target;
            this.duration = duration;
            this.transform = transform;
            this.coroutine = coroutine;
            DoTween.getInstance().Add(this);
        }
        
        //set the coroutine of tween
        public void setCoroutine(Coroutine coroutine)
        {
            this.coroutine = coroutine;
        }

        public void setAutoKill(bool isAutoKill)
        {
            this.isAutoKill = isAutoKill;
        }

        public void Play()
        {
            isPause = false;
        }

        public void Pause()
        {
            isPause = true;
        }

        public void Kill()
        {
            MonoBehaviour mono = transform.GetComponent<MonoBehaviour>();
            //Renderer rr = mat.GetComponent<Renderer>();
            mono.StopCoroutine(coroutine);
            //rr.StopCoroutine(coroutine);
            /*
            MeshRenderer msr = mono.GetComponent<MeshRenderer>();
            msr.material.color = Color.white;
            */
            DoTween.getInstance().Remove(this);
        }

        public void runOnComplete()
        {
            if (onComplete != null)
            {
                onComplete();
            }
            if (isAutoKill)
            {
                Kill();
            }
        }

        public void setOnComplete(OnComplete fun)
        {
            onComplete += fun;
        }
    }
}
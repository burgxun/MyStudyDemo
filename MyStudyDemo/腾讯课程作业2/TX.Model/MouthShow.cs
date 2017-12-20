using System;
using System.Collections.Generic;
using System.Text;

namespace TX.Model
{
    public abstract class MouthShow
    {
        public string OnePeople { get; set; }

        public string OneTable { get; set; }

        public string OneChair { get; set; }

        public string OneFan { get; set; }

        public string OneRuler { get; set; }

        public int Temperature { get; set; }

        protected int MaxTemperature { get; set; }

        /// <summary>
        /// 着火事件
        /// </summary>
        public event Action OnFireEvent;

        public void SetTemperature(int temperature)
        {
            Temperature = temperature;
        }

        public void ShowStart()
        {
            Console.WriteLine("口技表演开始了。。。");
        }

        public virtual void OnFire()
        {
            Console.Write("着火了~~~");
            if (Temperature > 400)
            {
                OnFireMethod();
            }
        }
        public void OnFireMethod()
        {
            if (OnFireEvent != null)
            {
                OnFireEvent.Invoke();
            }
        }

        public abstract void DogSound();

        public abstract void PeopleSound();

        public abstract void WindSound();

        public virtual void StartWorld()
        {
            Console.WriteLine(OnePeople + "：开场白。。。");
        }

        public virtual void EndWorld()
        {
            Console.WriteLine(OnePeople + "：结束语。。。");
        }
    }
}

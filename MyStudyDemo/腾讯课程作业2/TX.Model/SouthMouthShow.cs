using System;
using System.Collections.Generic;
using System.Text;
using TX.Interface;

namespace TX.Model
{
    public class SouthMouthShow : MouthShow, IGetFee
    {
        public SouthMouthShow()
        {
            MaxTemperature = 800;
        }

        public override void DogSound()
        {
            Console.WriteLine(OnePeople + "：模仿狗叫");
        }

        public override void PeopleSound()
        {
            Console.WriteLine(OnePeople + "：模仿人哭");
        }

        public override void WindSound()
        {
            Console.WriteLine(OnePeople + "：模仿风声");
        }

        public void MouthShowGetFee()
        {
            Console.WriteLine("口技表演结束--开始收费");
        }

        public override void StartWorld()
        {
            Console.WriteLine(OnePeople + "：表演开场白");
        }

        public override void OnFire()
        {
            if (base.Temperature >= MaxTemperature)
            {
                base.OnFireMethod();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TX.Interface;

namespace TX.Model
{
    public class NorthMouthShow : MouthShow, IGetFee
    {
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
            Console.WriteLine("-结束 开始收费");
        }

        public override void EndWorld()
        {
            Console.WriteLine(OnePeople + "--结束语");
        }
        
    }
}

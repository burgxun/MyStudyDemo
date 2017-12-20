using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TX.Factory;
using TX.Model;

namespace 腾讯课程作业2
{
    class Program
    {
        static void Main(string[] args)
        {

            SouthMouthShow mouthShowEntity = new SouthMouthShow() { OnePeople = "南派表演者", OneChair = "一椅", OneTable = "一桌", OneRuler = "一抚尺", OneFan = "一扇" };
            mouthShowEntity.Temperature = 800;
            mouthShowEntity.OnFireEvent += () => Console.WriteLine("夫起大呼");
            mouthShowEntity.OnFireEvent += () => Console.WriteLine("妇亦起大呼");
            mouthShowEntity.OnFireEvent += () => Console.WriteLine("两儿齐哭");
            mouthShowEntity.OnFireEvent += () => Console.WriteLine("俄而百千人大呼");
            mouthShowEntity.OnFireEvent += () => Console.WriteLine("百千犬吠");

           // MouthShowMethod.GetMothShow<SouthMouthShow>(mouthShowEntity);
            mouthShowEntity.OnFire();

        }
    }
}

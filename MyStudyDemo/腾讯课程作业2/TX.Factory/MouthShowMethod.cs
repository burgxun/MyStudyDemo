using System;
using System.Collections.Generic;
using System.Text;
using TX.Interface;
using TX.Model;

namespace TX.Factory
{
    public class MouthShowMethod
    {
        public static void GetMothShow<T>(T model) where T : MouthShow, IGetFee
        {
            Type type = typeof(T);
            foreach (var pop in type.GetProperties())
            {
                Console.WriteLine("属性名称：" + pop.Name + ";值：" + pop.GetValue(model));
            }
            MouthShow mouthShow = (MouthShow)model;
            mouthShow.ShowStart();
            mouthShow.StartWorld();
            mouthShow.DogSound();
            mouthShow.PeopleSound();
            mouthShow.WindSound();
            mouthShow.EndWorld();

            IGetFee getFee = (IGetFee)model;
            getFee.MouthShowGetFee();
        }
    }
}

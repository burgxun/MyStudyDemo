using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TX.Homework.Interface;

namespace TX.Homework.Model
{
    public class FryKingPrawn : AbstracDish, IDish
    {
        public override void CookDish()
        {
            Console.WriteLine("做菜中***,菜名叫:{0}", base.DishName);
        }
        public override double CommentsDish(string customerName)
        {
            double dishPoint = Math.Round((new Random().NextDouble()) * 10, 2);
            Console.WriteLine("客户{1},***************点评菜 给分{2},菜名称{0}", base.DishName, customerName, dishPoint);
            return dishPoint;
        }

        public void ShowDishName()
        {
            Console.WriteLine("这个菜的名字叫{0}", base.DishName);
        }
    }
}

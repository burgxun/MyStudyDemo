using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX.Homework.Interface
{
    public abstract class AbstracDish
    {
        public string DishName;

        public decimal DishPrice;

        public string Message;

        public void TasteDish(string customerName)
        {
            Console.WriteLine("客户{1},***************品尝菜,菜名称{0}", this.DishName, customerName);
        }

        public virtual double CommentsDish(string customerName)
        {
            double dishPoint = Math.Round((new Random().NextDouble()) * 10, 2);
            Console.WriteLine("客户{1},***************点评菜 给分{2},菜名称{0}", this.DishName, customerName, dishPoint);
            return dishPoint;
        }

        public abstract void CookDish();
    }
}

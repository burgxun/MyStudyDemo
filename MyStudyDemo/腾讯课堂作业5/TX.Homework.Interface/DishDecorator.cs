using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX.Homework.Interface
{
    public class DishDecorator : AbstracDish
    {

        private AbstracDish _AbstracDish = null;

        public DishDecorator(AbstracDish abstracDish)
        {
            _AbstracDish = abstracDish;
            this.DishName = abstracDish.DishName;
        }
        public override void CookDish()
        {
            _AbstracDish.CookDish();
        }
    }
    public class AfterDishDecorator : DishDecorator
    {
        public AfterDishDecorator(AbstracDish abstracDish) : base(abstracDish)
        {

        }

        public override void CookDish()
        {
            Console.WriteLine("做菜前***现在要做买菜、洗菜、切菜,菜名称：{0}", base.DishName);
            base.CookDish();
            Console.WriteLine("做菜后***做摆盘、上菜,菜名称：{0}", base.DishName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeAOP
{
    public class MyAOP
    {
        public static bool Save()
        {
            Customer customer = new Customer() { Age = 20, Name = "Test" };
            return customer.SaveCustomer();
        }
    }

    /// <summary>
    /// 特性 验证值
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class InValidateAttribute : Attribute
    {
        private int _MaxValue;
        private int _MinValue;
        public InValidateAttribute(int maxValue, int minValue)
        {
            _MaxValue = maxValue;
            _MinValue = minValue;
        }
        public bool InValidate(int validateValue)
        {
            return validateValue > _MinValue && validateValue < _MaxValue;
        }
    }

    [InValidate(0, 40)]
    public class Customer
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public static class CustomerExt
    {
        public static bool SaveCustomer(this Customer customer)
        {
            bool isSucess = false;
            Type type = customer.GetType();
            foreach (var pop in type.GetCustomAttributes(true))
            {
                if (pop is InValidateAttribute)
                {
                    InValidateAttribute inValidateAttribute = pop as InValidateAttribute;
                    isSucess = inValidateAttribute.InValidate(customer.Age);
                    break;
                }
            }
            return isSucess;
        }
    }
}

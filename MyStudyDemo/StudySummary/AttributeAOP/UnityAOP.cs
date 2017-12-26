using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace AttributeAOP
{
    public class UnityAOP
    {
        public static void TestUnityAOP()
        {
            User user = new User() { Id = 1, Name = "Test", Password = "123456" };
            IUnityContainer unityContainer = new UnityContainer();//声明一个容器
            unityContainer.RegisterType<IUserRegister, UserModel>();//声明UnityContainer并注册IUserRegister
            unityContainer.AddNewExtension<Interception>().Configure<Interception>().SetInterceptorFor<IUserRegister>(new InterfaceInterceptor());//注册特性
            IUserRegister userRegister = unityContainer.Resolve<IUserRegister>();//创建对象
            userRegister.UserRegister(user);//调用方法
        }
    }

    #region 特性行为
    public class RegisterHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            if (user.Password.Length < 0 || user.Password.Length > 20)
            {
                return input.CreateExceptionMethodReturn(new Exception("密码验证不过"));
            }
            return getNext()(input, getNext);
        }
    }

    public class LogHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            string message = string.Format("RegUser:Username:{0},Password:{1}", user.Name, user.Password);
            Console.WriteLine("日志已记录，Message:{0},Ctime:{1}", message, DateTime.Now);
            return getNext.Invoke().Invoke(input, getNext);
        }
    }
    #endregion

    #region 特性
    public class LogHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new LogHandler() { Order = this.Order };
        }
    }
    public class RegisterHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new RegisterHandler() { Order = this.Order };
        }
    }

    #endregion

    #region 要修饰的类等
    [LogHandler]
    [RegisterHandler]
    public interface IUserRegister
    {
        void UserRegister(User user);
    }

    public class UserModel : IUserRegister
    {
        public void UserRegister(User user)
        {
            Console.WriteLine("注册成功");
        }
    }

    #endregion
}

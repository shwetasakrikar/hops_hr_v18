
// Uncomment this class to provide custom runtime policy for Glimpse

using Glimpse.AspNet.Extensions;
using Glimpse.Core.Extensibility;

namespace GeneratorBase.MVC
{
    public class GlimpseSecurityPolicy : IRuntimePolicy
    {
        public RuntimePolicy Execute(IRuntimePolicyContext policyContext)
        {
            // You can perform a check like the one below to control Glimpse's permissions within your application.
            // More information about RuntimePolicies can be found at http://getglimpse.com/Help/Custom-Runtime-Policy
            // var httpContext = policyContext.GetHttpContext();
            // if (!httpContext.User.IsInRole("Administrator"))
            // {
            //     return RuntimePolicy.Off;
            // }
            //RuntimePolicy.ignore
            if (GeneratorBase.MVC.Models.CommonFunction.Instance.EnableGlimpse().ToLower() == "on")
            {
                return RuntimePolicy.On;
            }
            else
            {
                return RuntimePolicy.Off;
            }
        }

        public RuntimeEvent ExecuteOn
        {
            // The RuntimeEvent.ExecuteResource is only needed in case you create a security policy
            // Have a look at http://blog.getglimpse.com/2013/12/09/protect-glimpse-axd-with-your-custom-runtime-policy/ for more details
            get { return RuntimeEvent.EndRequest | RuntimeEvent.ExecuteResource; }
        }
    }
}

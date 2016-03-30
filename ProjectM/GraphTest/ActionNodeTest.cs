using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Graph;
using NUnit.Framework;

namespace GraphTest
{
    [TestFixture]
    public class ActionNodeTest
    {
        [Test]
        public void TestGetActionNode()
        {
            Type type = GetType();
            MethodInfo noParams = GetType().GetMethod("MethodNoParams");
            ActionNode noParamsNode = ActionNode.GetActionNode(noParams, this);

            Assert.That(noParamsNode.NumParams() == 0);

            MethodInfo oneParam = GetType().GetMethod("MethodOneParam");
            ActionNode oneParamNode = ActionNode.GetActionNode(oneParam, this);
            Assert.That(oneParamNode.NumParams() == 1);
        }

        public void MethodNoParams()
        {
        }

        public void MethodOneParam(int n)
        {
            
        }
    }
}

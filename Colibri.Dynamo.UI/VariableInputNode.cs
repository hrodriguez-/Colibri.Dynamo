using System.Collections.Generic;
using Dynamo.Graph.Nodes;
using ProtoCore.AST.AssociativeAST;
using Dynamo.Wpf;
using System;
using Dynamo.Controls;

namespace Colibri.Dynamo.UI
{
    /// <summary>
    /// 
    /// </summary>
    [NodeName("Domains")]
    [NodeDescription("Creates list of slider domains.")]
    [NodeCategory("Colibri.Dynamo.UI")]
    [IsDesignScriptCompatible]
    public class DomainsNode : VariableInputNode
    {
        /// <summary>
        ///     Report Node
        /// </summary>
        public DomainsNode()
        {
            InPortData.Add(new PortData("Slider0", "SliderDesc0"));
            OutPortData.Add(new PortData("Report", "OutToolTip0"));
            RegisterAllPorts();
            ArgumentLacing = LacingStrategy.Disabled;
        }

        /// <summary>
        ///     Get input name
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override string GetInputName(int index)
        {
            return "Slider" + index;
        }

        /// <summary>
        ///     Get input tooltip
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override string GetInputTooltip(int index)
        {
            return "SliderDesc" + index;
        }

        /// <summary>
        ///     Remove input
        /// </summary>
        protected override void RemoveInput()
        {
            if (InPortData.Count > 1)
                base.RemoveInput();
        }

        /// <summary>
        ///     Base implementation
        /// </summary>
        public override bool IsConvertible
        {
            get { return true; }
        }

        /// <summary>
        ///     AST Implementation
        /// </summary>
        /// <param name="inputAstNodes"></param>
        /// <returns></returns>
        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            if (IsPartiallyApplied)
            {
                return new[]
                {
                    AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode())
                };
            }

            AssociativeNode listNode = AstFactory.BuildExprList(inputAstNodes);

            List<AssociativeNode> start = new List<AssociativeNode>();
            List<AssociativeNode> end = new List<AssociativeNode>();
            List<AssociativeNode> name = new List<AssociativeNode>();
            for (int i=0; i < InPorts.Count; i++)
            {
                var node = InPorts[i].Connectors[0].Start.Owner as CoreNodeModels.Input.IntegerSlider;

                start.Add(AstFactory.BuildIntNode(node.Min));
                end.Add(AstFactory.BuildIntNode(node.Max));
                name.Add(AstFactory.BuildStringNode(node.Name));
            }

            AssociativeNode startNode = AstFactory.BuildExprList(start);
            AssociativeNode endNode = AstFactory.BuildExprList(end);
            AssociativeNode nameNode = AstFactory.BuildExprList(name);

            AssociativeNode functionCall =
                AstFactory.BuildFunctionCall(
                    new Func<List<int>, List<int>, List<string>, List<Domain>>(Utilities.Utilities.CreateDomains),
                    new List<AssociativeNode>() { startNode, endNode, nameNode });

            return new[]
            {
                AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), functionCall),
            };
        }
    }

    /// <summary>
    ///     View Customization
    /// </summary>
    public class MandrillReportViewCustomization : VariableInputNodeViewCustomization, INodeViewCustomization<DomainsNode>
    {
        /// <summary>
        ///     Customize view
        /// </summary>
        /// <param name="model"></param>
        /// <param name="nodeView"></param>
        public void CustomizeView(DomainsNode model, NodeView nodeView)
        {
            base.CustomizeView(model, nodeView);
        }
    }
}


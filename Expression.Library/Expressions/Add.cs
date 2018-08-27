﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.Library
{
    public class Add : ExpressionBase
    {
        public List<ExpressionBase> Expressions { get; private set; } = new List<ExpressionBase>();

        public Add() { }
        public Add(params ExpressionBase[] list) { Expressions.AddRange(list); }
        public Add(List<ExpressionBase> expressions) { Expressions.AddRange(expressions); }

        public void AddExpression(ExpressionBase expression)
        {
            Expressions.Add(expression);
        }

        public override double Evaluate(VariableReplacements replacements)
        {
            double result = 0;

            foreach(ExpressionBase ex in Expressions)
            {
                result += ex.Evaluate(replacements);
            }

            return result;
        }

        public override IEnumerable<Variable> Variables()
        {
            List<char> tokens = new List<char>();
            foreach (Variable v in Expressions.SelectMany(ex => ex.Variables()))
            {
                if(!tokens.Contains(v.Token))
                {
                    tokens.Add(v.Token);
                    yield return v;
                }
            }
        }
    }
}

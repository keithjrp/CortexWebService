// ***********************************************************************
// Assembly         : CortexWebService
// Author           : ktam
// Created          : 02-09-2015
//
// Last Modified By : ktam
// Last Modified On : 02-09-2015
// ***********************************************************************
// <copyright file="PredicateBuilder.cs" company="Amazon.com">
//     Copyright © Amazon.com 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

/// <summary>
/// The CortexWebService namespace.
/// </summary>
namespace CortexWebService
{
    /// <summary>
    /// Class PredicateBuilder.
    /// </summary>
    public static class PredicateBuilder
    {
        /// <summary>
        /// Trues this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        /// <summary>
        /// Falses this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        /// <summary>
        /// Ors the specified expr2.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1">The expr1.</param>
        /// <param name="expr2">The expr2.</param>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// Ands the specified expr2.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1">The expr1.</param>
        /// <param name="expr2">The expr2.</param>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}
﻿// -----------------------------------------------------------------------------
// Fur 是 .NET 5 平台下极易入门、极速开发的 Web 应用框架。
// Copyright © 2020 Fur, Baiqian Co.,Ltd.
//
// 框架名称：Fur
// 框架作者：百小僧
// 框架版本：1.0.0
// 源码地址：https://gitee.com/monksoul/Fur
// 开源协议：Apache-2.0（http://www.apache.org/licenses/LICENSE-2.0）
// -----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Fur.DatabaseAccessor
{
    /// <summary>
    /// Sql 查询仓储分部类
    /// </summary>
    /// <typeparam name="TDbContextLocator">数据库上下文定位器</typeparam>
    public partial class SqlRepository<TDbContextLocator>
        where TDbContextLocator : class, IDbContextLocator
    {
        /// <summary>
        /// Sql 查询返回 DataTable
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>DataTable</returns>
        public virtual DataTable SqlQuery(string sql, params object[] parameters)
        {
            return Database.ExecuteReader(sql, parameters);
        }

        /// <summary>
        /// Sql 查询返回 DataTable
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>DataTable</returns>
        public virtual DataTable SqlQuery(string sql, object model)
        {
            return Database.ExecuteReader(sql, model.ToSqlParameters());
        }

        /// <summary>
        /// Sql 查询返回 DataTable
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>Task<DataTable></returns>
        public virtual Task<DataTable> SqlQueryAsync(string sql, params object[] parameters)
        {
            return Database.ExecuteReaderAsync(sql, parameters);
        }

        /// <summary>
        /// Sql 查询返回 DataTable
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>Task<DataTable></returns>
        public virtual Task<DataTable> SqlQueryAsync(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            return Database.ExecuteReaderAsync(sql, parameters, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Sql 查询返回 DataTable
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>Task<DataTable></returns>
        public virtual Task<DataTable> SqlQueryAsync(string sql, object model, CancellationToken cancellationToken = default)
        {
            return Database.ExecuteReaderAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>List<T></returns>
        public virtual List<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return Database.ExecuteReader(sql, parameters).ToList<T>();
        }

        /// <summary>
        /// Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>List<T></returns>
        public virtual List<T> SqlQuery<T>(string sql, object model)
        {
            return Database.ExecuteReader(sql, model.ToSqlParameters()).ToList<T>();
        }

        /// <summary>
        /// Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>Task<List<T>></returns>
        public virtual async Task<List<T>> SqlQueryAsync<T>(string sql, params object[] parameters)
        {
            var dataTable = await Database.ExecuteReaderAsync(sql, parameters);
            return dataTable.ToList<T>();
        }

        /// <summary>
        /// Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>Task<List<T>></returns>
        public virtual async Task<List<T>> SqlQueryAsync<T>(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            var dataTable = await Database.ExecuteReaderAsync(sql, parameters, cancellationToken: cancellationToken);
            return dataTable.ToList<T>();
        }

        /// <summary>
        /// Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>Task<List<T>></returns>
        public virtual async Task<List<T>> SqlQueryAsync<T>(string sql, object model, CancellationToken cancellationToken = default)
        {
            var dataTable = await Database.ExecuteReaderAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
            return dataTable.ToList<T>();
        }

        /// <summary>
        ///  Sql 查询返回 DataSet
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>DataSet</returns>
        public virtual DataSet SqlQueries(string sql, params object[] parameters)
        {
            return Database.DataAdapterFill(sql, parameters);
        }

        /// <summary>
        ///  Sql 查询返回 DataSet
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>DataSet</returns>
        public virtual DataSet SqlQueries(string sql, object model)
        {
            return Database.DataAdapterFill(sql, model.ToSqlParameters());
        }

        /// <summary>
        ///  Sql 查询返回 DataSet
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>Task<DataSet></returns>
        public virtual Task<DataSet> SqlQueriesAsync(string sql, params object[] parameters)
        {
            return Database.DataAdapterFillAsync(sql, parameters);
        }

        /// <summary>
        ///  Sql 查询返回 DataSet
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>Task<DataSet></returns>
        public virtual Task<DataSet> SqlQueriesAsync(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            return Database.DataAdapterFillAsync(sql, parameters, cancellationToken: cancellationToken);
        }

        /// <summary>
        ///  Sql 查询返回 DataSet
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>Task<DataSet></returns>
        public virtual Task<DataSet> SqlQueriesAsync(string sql, object model, CancellationToken cancellationToken = default)
        {
            return Database.DataAdapterFillAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
        }

        /// <summary>
        ///  Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T1">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>List<T1></returns>
        public virtual List<T1> SqlQueries<T1>(string sql, params object[] parameters)
        {
            return Database.DataAdapterFill(sql, parameters).ToList<T1>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2) SqlQueries<T1, T2>(string sql, params object[] parameters)
        {
            return Database.DataAdapterFill(sql, parameters).ToList<T1, T2>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3) SqlQueries<T1, T2, T3>(string sql, params object[] parameters)
        {
            return Database.DataAdapterFill(sql, parameters).ToList<T1, T2, T3>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4) SqlQueries<T1, T2, T3, T4>(string sql, params object[] parameters)
        {
            return Database.DataAdapterFill(sql, parameters).ToList<T1, T2, T3, T4>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5) SqlQueries<T1, T2, T3, T4, T5>(string sql, params object[] parameters)
        {
            return Database.DataAdapterFill(sql, parameters).ToList<T1, T2, T3, T4, T5>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6) SqlQueries<T1, T2, T3, T4, T5, T6>(string sql, params object[] parameters)
        {
            return Database.DataAdapterFill(sql, parameters).ToList<T1, T2, T3, T4, T5, T6>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7) SqlQueries<T1, T2, T3, T4, T5, T6, T7>(string sql, params object[] parameters)
        {
            return Database.DataAdapterFill(sql, parameters).ToList<T1, T2, T3, T4, T5, T6, T7>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <typeparam name="T8">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7, List<T8> list8) SqlQueries<T1, T2, T3, T4, T5, T6, T7, T8>(string sql, params object[] parameters)
        {
            return Database.DataAdapterFill(sql, parameters).ToList<T1, T2, T3, T4, T5, T6, T7, T8>();
        }

        /// <summary>
        ///  Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T1">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>List<T1></returns>
        public virtual List<T1> SqlQueries<T1>(string sql, object model)
        {
            return Database.DataAdapterFill(sql, model.ToSqlParameters()).ToList<T1>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2) SqlQueries<T1, T2>(string sql, object model)
        {
            return Database.DataAdapterFill(sql, model.ToSqlParameters()).ToList<T1, T2>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3) SqlQueries<T1, T2, T3>(string sql, object model)
        {
            return Database.DataAdapterFill(sql, model.ToSqlParameters()).ToList<T1, T2, T3>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4) SqlQueries<T1, T2, T3, T4>(string sql, object model)
        {
            return Database.DataAdapterFill(sql, model.ToSqlParameters()).ToList<T1, T2, T3, T4>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5) SqlQueries<T1, T2, T3, T4, T5>(string sql, object model)
        {
            return Database.DataAdapterFill(sql, model.ToSqlParameters()).ToList<T1, T2, T3, T4, T5>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6) SqlQueries<T1, T2, T3, T4, T5, T6>(string sql, object model)
        {
            return Database.DataAdapterFill(sql, model.ToSqlParameters()).ToList<T1, T2, T3, T4, T5, T6>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7) SqlQueries<T1, T2, T3, T4, T5, T6, T7>(string sql, object model)
        {
            return Database.DataAdapterFill(sql, model.ToSqlParameters()).ToList<T1, T2, T3, T4, T5, T6, T7>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <typeparam name="T8">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <returns>元组类型</returns>
        public virtual (List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7, List<T8> list8) SqlQueries<T1, T2, T3, T4, T5, T6, T7, T8>(string sql, object model)
        {
            return Database.DataAdapterFill(sql, model.ToSqlParameters()).ToList<T1, T2, T3, T4, T5, T6, T7, T8>();
        }

        /// <summary>
        ///  Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T1">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>Task<List<T1>></returns>
        public virtual async Task<List<T1>> SqlQueriesAsync<T1>(string sql, params object[] parameters)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters);
            return dataset.ToList<T1>();
        }

        /// <summary>
        ///  Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T1">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>Task<List<T1>></returns>
        public virtual async Task<List<T1>> SqlQueriesAsync<T1>(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters, cancellationToken: cancellationToken);
            return dataset.ToList<T1>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2)> SqlQueriesAsync<T1, T2>(string sql, params object[] parameters)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters);
            return dataset.ToList<T1, T2>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2)> SqlQueriesAsync<T1, T2>(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters, cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3)> SqlQueriesAsync<T1, T2, T3>(string sql, params object[] parameters)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters);
            return dataset.ToList<T1, T2, T3>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3)> SqlQueriesAsync<T1, T2, T3>(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters, cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4)> SqlQueriesAsync<T1, T2, T3, T4>(string sql, params object[] parameters)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters);
            return dataset.ToList<T1, T2, T3, T4>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4)> SqlQueriesAsync<T1, T2, T3, T4>(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters, cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5)> SqlQueriesAsync<T1, T2, T3, T4, T5>(string sql, params object[] parameters)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters);
            return dataset.ToList<T1, T2, T3, T4, T5>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5)> SqlQueriesAsync<T1, T2, T3, T4, T5>(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters, cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4, T5>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6)> SqlQueriesAsync<T1, T2, T3, T4, T5, T6>(string sql, params object[] parameters)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters);
            return dataset.ToList<T1, T2, T3, T4, T5, T6>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6)> SqlQueriesAsync<T1, T2, T3, T4, T5, T6>(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters, cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4, T5, T6>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7)> SqlQueriesAsync<T1, T2, T3, T4, T5, T6, T7>(string sql, params object[] parameters)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters);
            return dataset.ToList<T1, T2, T3, T4, T5, T6, T7>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7)> SqlQueriesAsync<T1, T2, T3, T4, T5, T6, T7>(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters, cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4, T5, T6, T7>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <typeparam name="T8">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7, List<T8> list8)> SqlQueriesAsync<T1, T2, T3, T4, T5, T6, T7, T8>(string sql, params object[] parameters)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters);
            return dataset.ToList<T1, T2, T3, T4, T5, T6, T7, T8>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <typeparam name="T8">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">命令参数</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7, List<T8> list8)> SqlQueriesAsync<T1, T2, T3, T4, T5, T6, T7, T8>(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, parameters, cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4, T5, T6, T7, T8>();
        }

        /// <summary>
        ///  Sql 查询返回 List 集合
        /// </summary>
        /// <typeparam name="T1">返回类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>List<T1></returns>
        public virtual async Task<List<T1>> SqlQueriesAsync<T1>(string sql, object model, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
            return dataset.ToList<T1>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2)> SqlQueriesAsync<T1, T2>(string sql, object model, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3)> SqlQueriesAsync<T1, T2, T3>(string sql, object model, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4)> SqlQueriesAsync<T1, T2, T3, T4>(string sql, object model, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5)> SqlQueriesAsync<T1, T2, T3, T4, T5>(string sql, object model, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4, T5>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6)> SqlQueriesAsync<T1, T2, T3, T4, T5, T6>(string sql, object model, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4, T5, T6>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7)> SqlQueriesAsync<T1, T2, T3, T4, T5, T6, T7>(string sql, object model, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4, T5, T6, T7>();
        }

        /// <summary>
        /// Sql 查询返回 元组 集合
        /// </summary>
        /// <typeparam name="T1">元组元素类型</typeparam>
        /// <typeparam name="T2">元组元素类型</typeparam>
        /// <typeparam name="T3">元组元素类型</typeparam>
        /// <typeparam name="T4">元组元素类型</typeparam>
        /// <typeparam name="T5">元组元素类型</typeparam>
        /// <typeparam name="T6">元组元素类型</typeparam>
        /// <typeparam name="T7">元组元素类型</typeparam>
        /// <typeparam name="T8">元组元素类型</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="model">参数模型</param>
        /// <param name="cancellationToken">异步取消令牌</param>
        /// <returns>元组类型</returns>
        public virtual async Task<(List<T1> list1, List<T2> list2, List<T3> list3, List<T4> list4, List<T5> list5, List<T6> list6, List<T7> list7, List<T8> list8)> SqlQueriesAsync<T1, T2, T3, T4, T5, T6, T7, T8>(string sql, object model, CancellationToken cancellationToken = default)
        {
            var dataset = await Database.DataAdapterFillAsync(sql, model.ToSqlParameters(), cancellationToken: cancellationToken);
            return dataset.ToList<T1, T2, T3, T4, T5, T6, T7, T8>();
        }
    }
}
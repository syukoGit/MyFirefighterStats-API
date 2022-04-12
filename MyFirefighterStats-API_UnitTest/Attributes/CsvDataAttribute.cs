// -----------------------------------------------------------------------
//  <copyright project="MyFirefighterStats-API_UnitTest" file="CsvDataAttribute.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace MyFirefighterStats.API.Attributes;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public sealed class CsvDataAttribute : DataAttribute
{
    private const char Delimiter = ';';

    private readonly string[] columnsToIgnore = Array.Empty<string>();

    private readonly string fileName;

    public CsvDataAttribute(string fileName) => this.fileName = fileName;

    public CsvDataAttribute(string fileName, params string[] columnsToIgnore)
        : this(fileName) => this.columnsToIgnore = columnsToIgnore;

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        ParameterInfo[] pars = testMethod.GetParameters();
        Type[] parameterTypes = pars.Select(static par => par.ParameterType).ToArray();

        using var csvFile = new StreamReader(this.fileName);

        string? header = csvFile.ReadLine();

        IEnumerable<int> columnsIndexToIgnore = new List<int>();

        if (header != null)
        {
            columnsIndexToIgnore = GetColumnIndexesToIgnore(header, this.columnsToIgnore).ToList();
        }

        string? line;

        while ((line = csvFile.ReadLine()) != null)
        {
            List<string> row = line.Split(Delimiter).ToList();

            foreach (int index in columnsIndexToIgnore)
            {
                row.RemoveAt(index);
            }

            yield return ConvertParameters(row, parameterTypes);
        }
    }

    private static object ConvertParameter(object parameter, Type parameterType) => parameterType == typeof(int)
                                                                                        ? Convert.ToInt32(parameter)
                                                                                        : parameter;

    private static object[] ConvertParameters(IReadOnlyList<object> values, IReadOnlyList<Type> parameterTypes)
    {
        var result = new object[parameterTypes.Count];

        for (var i = 0; i < parameterTypes.Count; i++)
        {
            result[i] = ConvertParameter(values[i], parameterTypes[i]);
        }

        return result;
    }

    private static IEnumerable<int> GetColumnIndexesToIgnore(string header, IEnumerable<string> columnsToIgnore)
    {
        List<string> headerColumns = header.Split(Delimiter).ToList();

        return columnsToIgnore.Select(column => headerColumns.IndexOf(column)).Where(static index => index != -1);
    }
}
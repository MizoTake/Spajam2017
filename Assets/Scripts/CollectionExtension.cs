using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// リストの拡張メソッド
/// </summary>
public static class CollectionExtension
{
	/// <summary>
	/// コレクション内に要素があるか
	/// </summary>
	/// <returns><c>true</c> if is any the specified collection; otherwise, <c>false</c>.</returns>
	/// <param name="collection">Collection.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static bool IsAny<T> (this IEnumerable<T> collection) {
		return (collection != null && collection.Any());
	}

	/// <summary>
	/// 簡易foreach
	/// </summary>
	/// <param name="collection">Collection.</param>
	/// <param name="action">Action.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static void ForEach<T> (this IEnumerable<T> collection, Action<T> action)
	{
		foreach (T t in collection) {
			action (t);
		}
	}

	/// <summary>
	/// 簡易foreach(index付き)
	/// </summary>
	/// <param name="collection">Collection.</param>
	/// <param name="action">Action.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static void ForEach<T> (this IEnumerable<T> collection, Action<T, int> action)
	{
		int i = 0;
		foreach (T t in collection) {
			action (t, i++);
		}
	}
}

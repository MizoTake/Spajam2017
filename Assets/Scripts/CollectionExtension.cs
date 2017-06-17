using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectionExtension
{
	public static bool IsAny<T> (this IEnumerable<T> collection) {
		return (collection != null && collection.Any());
	}

	public static void ForEach<T> (this IEnumerable<T> collection, Action<T> action)
	{
		foreach (T t in collection) {
			action (t);
		}
	}

	public static void ForEach<T> (this IEnumerable<T> collection, Action<T, int> action)
	{
		int i = 0;
		foreach (T t in collection) {
			action (t, i++);
		}
	}
}

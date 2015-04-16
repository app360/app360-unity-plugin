using UnityEngine;
using System.Collections;
using System;
using App360SDK.Api;

public class App360TransactionEventArgs : EventArgs
{
	public Transaction transaction { get; set; }
}

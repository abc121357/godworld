using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace Remiix.Skip {

	[AttributeUsage (AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Event)]
	public class SkipRenameAttribute : System.Attribute {
	}

	[SkipRename]
	public class SkipAllAttribute : System.Attribute {
	}

	[SkipRename]
	public class SkipFakeMethodAttribute : System.Attribute {
	}

	[SkipRename]
	public class SkipStringEncryptionAttribute : System.Attribute {
	}
}
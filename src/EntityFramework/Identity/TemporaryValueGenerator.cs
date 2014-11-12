// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity.Identity
{
    public class TemporaryValueGenerator : SimpleValueGenerator
    {
        private long _current;

        public override GeneratedValue Next(IProperty property)
        {
            Check.NotNull(property, "property");

            return new GeneratedValue(
                Convert.ChangeType(Interlocked.Decrement(ref _current), property.PropertyType.UnwrapNullableType()),
                isTemporary: true);
        }
    }
}

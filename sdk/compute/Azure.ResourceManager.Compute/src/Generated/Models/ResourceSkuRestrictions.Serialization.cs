// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class ResourceSkuRestrictions
    {
        internal static ResourceSkuRestrictions DeserializeResourceSkuRestrictions(JsonElement element)
        {
            ResourceSkuRestrictionsType? type = default;
            IReadOnlyList<string> values = default;
            ResourceSkuRestrictionInfo restrictionInfo = default;
            ResourceSkuRestrictionsReasonCode? reasonCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = property.Value.GetString().ToResourceSkuRestrictionsType();
                    continue;
                }
                if (property.NameEquals("values"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetString());
                        }
                    }
                    values = array;
                    continue;
                }
                if (property.NameEquals("restrictionInfo"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    restrictionInfo = ResourceSkuRestrictionInfo.DeserializeResourceSkuRestrictionInfo(property.Value);
                    continue;
                }
                if (property.NameEquals("reasonCode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    reasonCode = property.Value.GetString().ToResourceSkuRestrictionsReasonCode();
                    continue;
                }
            }
            return new ResourceSkuRestrictions(type, values, restrictionInfo, reasonCode);
        }
    }
}

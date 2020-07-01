using AwsLayers.Util.Models;
using System;
using System.Collections.Generic;

namespace AwsLayers.Util
{
    public interface IValuesUtility
    {
        IEnumerable<Value> Seed();
    }

    public class ValuesUtility : IValuesUtility
    {
        public IEnumerable<Value> Seed()
        {
            var values = new List<Value>();

            for (int i = 1000; i < 1100; i++)
            {
                values.Add(new Value
                {
                    Id = Guid.NewGuid(),
                    ItemValue = i*6
                });
            }

            return values;
        }
    }
}

﻿/*
 * Copyright (c) 2014 Optimal Payments
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute,
 * sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
 * NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OptimalPayments.Common;

namespace OptimalPayments.HostedPayment
{
    public class Pagerator<T> : AbstractPagerator<T>
    {
        public Pagerator(OptimalApiClient apiClient, Type pagingClassType, Dictionary<string, object> data)
            : base(apiClient, pagingClassType)
        {
            this.parseResponse(data);
        }

        override protected sealed void parseResponse(Dictionary<string, dynamic> data)
        {
            if (!data.ContainsKey(this.arrayKey) || !(data[this.arrayKey] is List<dynamic>))
            {
                throw new OptimalException("Missing array key from results");
            }
            foreach(dynamic obj in data[this.arrayKey] as List<dynamic>) {
                Object[] args = { obj };
                dynamic result = Activator.CreateInstance(this.classType, args);
                this.results.Add(result);
            }
            this.nextPage = null;

            if (data.ContainsKey("navigation")
                && ((Dictionary<string, dynamic>)data["navigation"]).ContainsKey("next"))
            {
                this.nextPage = (String)data["navigation"]["next"];
            }
        }
    }
}

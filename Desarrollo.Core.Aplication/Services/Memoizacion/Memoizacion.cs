using Desarrollo.Core.Domain.Models;
using Desarrollo.Core.Persistencia.Repositories.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Aplication.Services.Memoizacion
{
    public static class Memoizacion
    {


       public static Func<T, TResult> Memoizes <T, TResult>(this Func<T, TResult> func)
        {

            var cache= new ConcurrentDictionary<T, TResult> ();

            return (a)=> cache.GetOrAdd(a,func);    

        }

    }
}

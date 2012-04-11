using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progressive.TimeAttackOnline.Models;
using Codeplex.Data;

namespace Progressive.TimeAttackOnline.Models
{
    internal static class AsyncExtensions
    {
        internal static Task<bool?> AddEventAsync(this ServerModel model, string passPhrase, string title, DateTime startTime)
        {
            return Task.Factory.FromAsync(
                (ar, state) => model.BeginAddEvent(ar, state, passPhrase, title, startTime),
                ar => model.EndAddEvent(ar),
                null);
        }

        internal static Task<Tuple<bool?, string>> GetEventAsync(this ServerModel model, string passPhrase)
        {
            return Task.Factory.FromAsync(
                (ar, state) => model.BeginGetEvent(ar, state, passPhrase),
                ar =>
                {
                    string json;
                    bool? result = model.EndGetEvent(ar, out json);
                    if (result != true)
                    {
                        return Tuple.Create(result, "");
                    }
                    return Tuple.Create(true as bool?, json);
                },
                null);
        }
    }
}
